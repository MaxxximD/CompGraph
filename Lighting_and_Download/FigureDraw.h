// Рисует кубик в клеточку

#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <algorithm>
#include <math.h>

// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
// ID атрибута
GLint Attrib_normal;
GLint Attrib_texture;
// ID Vertex Buffer Object
GLuint vertexVBO;
GLuint normalVBO;
GLuint textureVBO;

// ID юниформ углов
GLint Unif_angles;
GLint Unif_lightingNumber;
//---------------------------------
float angles[2] = { 1, 1 };

int lightingNumber = 1;
std::string path = "cube.obj";
//---------------------------------

//Кол-во граней*3
int faceCount;

// ID Transform struct
GLint Unif_transform_model;
GLint Unif_transform_viewProjection;
GLint Unif_transform_normal;
GLint Unif_transform_viewPosition;

// ID Material struct
GLint Unif_material_emission;
GLint Unif_material_ambient;
GLint Unif_material_diffuse;
GLint Unif_material_specular;
GLint Unif_material_shininess;

// ID LigtPoint struct
GLint Unif_light_ambient;
GLint Unif_light_diffuse;
GLint Unif_light_specular;
GLint Unif_light_attenuation;
GLint Unif_light_position;

struct Transform
{
    float model[4][4] =
    {
        {1.0, 0.0, 0.0, 0.0},
        {0.0, 1.0, 0.0, 0.0},
        {0.0, 0.0, 1.0, 0.0},
        {0.0, 0.0, 0.0, 1.0},
    };
    float viewProjection[4][4] =
    {
        {1.0, 0.0, 0.0, 0.0},
        {0.0, 1.0, 0.0, 0.0},
        {0.0, 0.0, 1.0, 0.0},
        {0.0, 0.0, 0.0, 1.0},
    };
    float normal[3][3] =
    {
        {1.0, 0.0, 0.0},
        {0.0, 1.0, 0.0},
        {0.0, 0.0, 1.0},
    };
    float viewPosition[3] = { -1.0f, -1.0f, -1.0f };
} transform;

struct Material
{
    float ambient[4] = { 0.24725f, 0.1995f, 0.0745f, 1.0f };
    float emission[4] = { 0.0f, 0.0f, 0.0f, 0.0f };
    float diffuse[4] = { 0.75164f, 0.60648f, 0.22648f, 1.0f };
    float specular[4] = { 0.628281f, 0.555802f, 0.366065f, 1.0f };
    float shininess = 0.4f;
} material;

struct PointLight
{
    float ambient[4] = { 0.1f, 0.1f, 0.1f, 1.0f };
    float diffuse[4] = { 0.4f, 0.4f, 0.4f, 1.0f };
    float specular[4] = { 0.6f, 0.6f, 0.6f, 0.6f };
    float attenuation[3] = { 1.0f, 0.0f, 0.0f };
    float position[3] = { -1.0f, -1.0f, -1.0f };
} light;

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
    #version 330 core

    // Координаты вершины. Атрибут, инициализируется через буфер.
    in vec3 position;
    in vec3 normal;

    uniform vec2 in_angles;

    uniform struct Transform {
		mat4 model;
		mat4 viewProjection;
		mat3 normal;
		vec3 viewPosition;
	} transform;

	uniform struct PointLight {
		vec3 position;
		vec4 ambient;
		vec4 diffuse;
		vec4 specular;
		vec3 attenuation;
	} light;

	out Vertex {
		//vec3 texcoord;
		vec3 normal;
		vec3 lightDir;
		vec3 viewDir;
		float distance;
	} Vert;

    void main() {

        // Захардкодим углы поворота
        float x_angle = in_angles[0];
        float y_angle = in_angles[1];
        
        // Поворачиваем вершину
        mat3 rotate = mat3(
            1, 0, 0,
            0, cos(x_angle), -sin(x_angle),
            0, sin(x_angle), cos(x_angle)
        ) * mat3(
            cos(y_angle), 0, sin(y_angle),
            0, 1, 0,
            -sin(y_angle), 0, cos(y_angle)
        ) * mat3(
			cos(0), -sin(0), 0,
			sin(0), cos(0), 0,
			0, 0, 1
		);

        vec3 vertex = position * rotate;
		vec3 lightDir = light.position - vertex;
		gl_Position = vec4(vertex, 1.0);
		
		Vert.normal = normal * rotate;
		Vert.lightDir = lightDir;
		Vert.viewDir = transform.viewPosition - vertex;
		Vert.distance = length(lightDir);
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core

    in Vertex {
		//vec3 texcoord;
		vec3 normal;
		vec3 lightDir;
		vec3 viewDir;
		float distance;
	} Vert;

	uniform struct PointLight {
		vec3 position;
		vec4 ambient;
		vec4 diffuse;
		vec4 specular;
		vec3 attenuation;
	} light;

	uniform struct Material {
		vec4 ambient;
		vec4 diffuse;
		vec4 specular;
		vec4 emission;
		float shininess;
	} material;

    uniform int lightingNumber; //Номер освещения 

    out vec4 color;

    vec4 toonShading(){
        vec3 normal = normalize(Vert.normal);
	    vec3 lightDir = normalize(Vert.lightDir);
	    float diff = 0.2 + max(dot(normal, lightDir), 0.0);

        if(diff < 0.4)
            return material.diffuse * 0.3;
        else if(diff < 0.7)
            return material.diffuse;
        else
            return material.diffuse * 1.3;
    }

    vec4 Blinn_Phong(){
        vec4 color_;
        vec3 normal = normalize(Vert.normal);
	    vec3 lightDir = normalize(Vert.lightDir);
	    vec3 viewDir = normalize(Vert.viewDir);
        float attenuation = 1.0/(light.attenuation[0] + light.attenuation[1] * Vert.distance + light.attenuation[2] * Vert.distance * Vert.distance); 	
        color_ = material.emission;
        color_ += material.ambient * light.ambient * attenuation;
        float Ndot = max(dot(normal,lightDir),0.0);
        color_ += material.diffuse * light.diffuse * Ndot* attenuation;
        float RdotVpow = max(pow(dot(reflect (-lightDir, normal), viewDir), material.shininess),0.0);
        color_ += material.specular * light.specular * RdotVpow * attenuation;
        return color_;
    }

    vec4 Minnaert(){
        const float k = 0.8;
		vec3  n2 = normalize(Vert.normal);
		vec3  l2 = normalize(Vert.lightDir);
		vec3  v2 = normalize(Vert.viewDir);
		float d1 = pow(max(dot(n2, l2), 0.0), 1.0 + k);
		float d2 = pow(1.0 - dot(n2, v2), 1.0 - k);
		return material.diffuse * d1 * d2;
    }
    void main() {
        if(lightingNumber == 1 )
            color = Blinn_Phong();
        else if(lightingNumber == 2 )	
            color = toonShading();
        else color = Minnaert();
    }
)";


void Init();
void Draw();
void Release();


// Инкремент угла
void inc_coord(int index) {
    angles[index] += 0.1;
}

// Декремент угла
void dec_coord(int index) {
    angles[index] -= 0.1;
}

int figureDraw(std::string path_, int lightingNumber_) {

    //---------------------------------
    path = path_;
    lightingNumber = lightingNumber_;
    //---------------------------------

    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // Инициализация glew
    glewInit();

    Init();

    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                window.close();
            }
            else if (event.type == sf::Event::Resized) {
                glViewport(0, 0, event.size.width, event.size.height);
            }
            // обработка нажатий клавиш
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                case (sf::Keyboard::W): inc_coord(0); break;
                case (sf::Keyboard::D): dec_coord(1); break;
                case (sf::Keyboard::S): dec_coord(0); break;
                case (sf::Keyboard::A): inc_coord(1); break;

                case (sf::Keyboard::Num1): lightingNumber = 1; break;
                case (sf::Keyboard::Num2): lightingNumber = 2; break;
                case (sf::Keyboard::Num3): lightingNumber = 3; break;

                case (sf::Keyboard::Z): path = "cube.obj"; Init(); break;
                case (sf::Keyboard::X): path = "sphere.obj"; Init(); break;
                default: break;
                }
            }
        }

        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        Draw();

        window.display();
    }

    Release();
    return 0;
}


// Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
void checkOpenGLerror() {
    GLenum errCode;
    // Коды ошибок можно смотреть тут
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error!: " << errCode << std::endl;
}

// Функция печати лога шейдера
void ShaderLog(unsigned int shader)
{
    int infologLen = 0;
    int charsWritten = 0;
    char* infoLog;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        infoLog = new char[infologLen];
        if (infoLog == NULL)
        {
            std::cout << "ERROR: Could not allocate InfoLog buffer" << std::endl;
            exit(1);
        }
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog);
        std::cout << "InfoLog: " << infoLog << "\n\n\n";
        delete[] infoLog;
    }
}


void InitVBO()
{
    glGenBuffers(1, &vertexVBO);
    glGenBuffers(1, &normalVBO);
    //glGenBuffers(1, &textureVBO);

    Figure* f = new Figure(path);

    faceCount = f->faces.size() * 3;

    std::vector<float> v = get_Vert2(f);
    std::cout << "Vertex: yes;" << std::endl;
    std::vector<float> n = get_Norm2(f);
    std::cout << "Normal: yes;" << std::endl;
    std::vector<float> t = get_Text2(f);
    std::cout << "Texture: yes;" << std::endl;

    std::cout << "--------------------------------------------------------------------" << std::endl;
    std::cout << "f->faces[0].size(): " << f->faces[0].size() << std::endl;
    std::cout << "f->faces.size(): " << f->faces.size() << std::endl;
    std::cout << "faceCount: " << faceCount << std::endl;
    std::cout << "v.size(): " << v.size() << std::endl;
    std::cout << "n.size(): " << n.size() << std::endl;
    std::cout << "t.size(): " << t.size() << std::endl;
    std::cout << "--------------------------------------------------------------------" << std::endl;

    /*int k = 0;
    int k_2 = 0;
    for (int i = 0; i < n.size(); i++) {
        std::cout << n[i] << " ";
        k++;
        if (k == 3) {
            std::cout << std::endl;
            k = 0;
            k_2++;
        }
        if (k_2 == 3) {
            std::cout << std::endl;
            k_2 = 0;
        }
    }
    std::cout << std::endl;*/

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, vertexVBO);
    glBufferData(GL_ARRAY_BUFFER, v.size() * sizeof(GLfloat), v.data(), GL_STATIC_DRAW);

    glBindBuffer(GL_ARRAY_BUFFER, normalVBO);
    glBufferData(GL_ARRAY_BUFFER, n.size() * sizeof(GLfloat), n.data(), GL_STATIC_DRAW);

    //glBindBuffer(GL_ARRAY_BUFFER, textureVBO);
    //glBufferData(GL_ARRAY_BUFFER, t.size() * sizeof(GLfloat), t.data(), GL_STATIC_DRAW);


    checkOpenGLerror();
}


void InitShader() {
    // Создаем вершинный шейдер
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // Передаем исходный код
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    // Создаем фрагментный шейдер
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // Передаем исходный код
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    ShaderLog(fShader);

    // Создаем программу и прикрепляем шейдеры к ней
    Program = glCreateProgram();
    glAttachShader(Program, vShader);
    glAttachShader(Program, fShader);

    // Линкуем шейдерную программу
    glLinkProgram(Program);
    // Проверяем статус сборки
    int link_ok;
    glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
    if (!link_ok)
    {
        std::cout << "error attach shaders \n";
        return;
    }

    // Вытягиваем ID атрибута из собранной программы
    const char* attr_name = "position";
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }

    // Вытягиваем ID атрибута из собранной программы
    Attrib_normal = glGetAttribLocation(Program, "normal");
    if (Attrib_normal == -1)
    {
        std::cout << "could not bind normal" << std::endl;
        return;
    }

    // Вытягиваем ID атрибута из собранной программы
    /*Attrib_texture = glGetAttribLocation(Program, "texture");
    if (Attrib_texture == -1)
    {
        std::cout << "could not bind texture" << std::endl;
        return;
    }*/

    //---------------------------------------------------------------------------------------------------------

    // Вытягиваем ID юниформ
    const char* unif_name = "in_angles";
    Unif_angles = glGetUniformLocation(Program, unif_name);
    if (Unif_angles == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }

    Unif_lightingNumber = glGetUniformLocation(Program, "lightingNumber");
    if (Unif_lightingNumber == -1)
    {
        std::cout << "could not bind Unif_lightingNumber " << unif_name << std::endl;
        return;
    }
    //---------------------------------------------------------------------------------------------------------

    Unif_material_ambient = glGetUniformLocation(Program, "material.ambient");
    if (Unif_material_ambient == -1)
    {
        std::cout << "could not bind uniform material.ambient" << std::endl;
        //return;
    }

    Unif_material_diffuse = glGetUniformLocation(Program, "material.diffuse");
    if (Unif_material_diffuse == -1)
    {
        std::cout << "could not bind uniform material.diffuse" << std::endl;
        //return;
    }

    Unif_material_emission = glGetUniformLocation(Program, "material.emission");
    if (Unif_material_emission == -1)
    {
        std::cout << "could not bind uniform material.emission" << std::endl;
        //return;
    }

    Unif_material_specular = glGetUniformLocation(Program, "material.specular");
    if (Unif_material_specular == -1)
    {
        std::cout << "could not bind uniform material.specular" << std::endl;
        //return;
    }

    Unif_material_shininess = glGetUniformLocation(Program, "material.shininess");
    if (Unif_material_specular == -1)
    {
        std::cout << "could not bind uniform material.shininess" << std::endl;
        //return;
    }

    Unif_light_position = glGetUniformLocation(Program, "light.position");
    if (Unif_light_position == -1)
    {
        std::cout << "could not bind uniform light.position" << std::endl;
        //return;
    }

    Unif_light_ambient = glGetUniformLocation(Program, "light.ambient");
    if (Unif_light_ambient == -1)
    {
        std::cout << "could not bind uniform light.ambient" << std::endl;
        //return;
    }

    Unif_light_diffuse = glGetUniformLocation(Program, "light.diffuse");
    if (Unif_light_diffuse == -1)
    {
        std::cout << "could not bind uniform light.diffuse" << std::endl;
        //return;
    }

    Unif_light_specular = glGetUniformLocation(Program, "light.specular");
    if (Unif_light_specular == -1)
    {
        std::cout << "could not bind uniform light.specular" << std::endl;
        //return;
    }

    Unif_light_attenuation = glGetUniformLocation(Program, "light.attenuation");
    if (Unif_light_attenuation == -1)
    {
        std::cout << "could not bind uniform light.attenuation" << std::endl;
        //return;
    }

    checkOpenGLerror();
}

void Init() {
    InitShader();
    InitVBO();
    // Включаем проверку глубины
    glEnable(GL_DEPTH_TEST);
}


void Draw() {
    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);
    
    // Передаем юниформ в шейдер
    glUniform2fv(Unif_angles, 1, angles);
    glUniform1i(Unif_lightingNumber, lightingNumber);
    //--------------------------------------------------------
    //Освещение
    glUniform3fv(Unif_transform_viewPosition, 1, transform.viewPosition);

    glUniform4fv(Unif_material_ambient, 1, material.ambient);
    glUniform4fv(Unif_material_diffuse, 1, material.diffuse);
    glUniform4fv(Unif_material_specular, 1, material.specular);
    glUniform4fv(Unif_material_emission, 1, material.emission);
    glUniform1f(Unif_material_shininess, material.shininess);

    glUniform3fv(Unif_light_position, 1, light.position);
    glUniform4fv(Unif_light_ambient, 1, light.ambient);
    glUniform4fv(Unif_light_diffuse, 1, light.diffuse);
    glUniform4fv(Unif_light_specular, 1, light.specular);
    glUniform3fv(Unif_light_attenuation, 1, light.attenuation);
    //--------------------------------------------------------

    glEnableVertexAttribArray(Attrib_vertex);
    glBindBuffer(GL_ARRAY_BUFFER, vertexVBO);
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);
    
    glEnableVertexAttribArray(Attrib_normal);
    glBindBuffer(GL_ARRAY_BUFFER, normalVBO);
    glVertexAttribPointer(Attrib_normal, 3, GL_FLOAT, GL_FALSE, 0, 0);

    /*glEnableVertexAttribArray(Attrib_texture);
    glBindBuffer(GL_ARRAY_BUFFER, textureVBO);
    glVertexAttribPointer(Attrib_normal, 3, GL_FLOAT, GL_FALSE, 0, 0);*/

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_TRIANGLES, 0, faceCount);

    // Отключаем массив атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_normal);
    //glDisableVertexAttribArray(Attrib_texture);

    // Отключаем шейдерную программу
    glUseProgram(0);
    checkOpenGLerror();
}


// Освобождение шейдеров
void ReleaseShader() {
    // Передавая ноль, мы отключаем шейдрную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(Program);
}

// Освобождение буфера
void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &vertexVBO);
    glDeleteBuffers(1, &normalVBO);
    //glDeleteBuffers(1, &textureVBO);

}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}
