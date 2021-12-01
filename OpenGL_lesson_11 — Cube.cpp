﻿// Рисует кубик в клеточку

#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>


// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;
// ID юниформ переменной цвета
GLint Unif_color;
// ID юниформ углов
GLint Unif_angles;
// ID VBO вершин
GLuint VBO_position;
// ID VBO цвета
GLuint VBO_color;
// Вершина
struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;
};

float angles[2] = { 1, 1 };

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
    #version 330 core

    // Координаты вершины. Атрибут, инициализируется через буфер.
    in vec3 vertexPosition;
    
    in vec4 color;

    uniform vec2 in_angles;

    // Выходной параметр с координатами вершины, интерполируется и передётся во фрагментный шейдер 
    out vec3 vPosition;

    out vec4 vert_color;
    
    void main() {
        // Передаём непреобразованную координату во фрагментный шейдер
        vPosition = vertexPosition;
        
        // Захардкодим углы поворота
        float x_angle = in_angles[0];
        float y_angle = in_angles[1];

        //float x_angle = 1;
        //float y_angle = 1;

        // Поворачиваем вершину
        vec3 position = vertexPosition * mat3(
            1, 0, 0,
            0, cos(x_angle), -sin(x_angle),
            0, sin(x_angle), cos(x_angle)
        ) * mat3(
            cos(y_angle), 0, sin(y_angle),
            0, 1, 0,
            -sin(y_angle), 0, cos(y_angle)
        );

        // Присваиваем вершину волшебной переменной gl_Position
        gl_Position = vec4(position, 1.0);

        vert_color = color;
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core

    // Интерполированные координаты вершины, передаются из вершинного шейдера
    in vec3 vPosition;

    in vec4 vert_color;

    // Цвет, который будем отрисовывать
    out vec4 color;

    void main() {
        color = vert_color;
    }
)";


void Init();
void Draw();
void Release();

// Инкремент цветовой компоненты цвета
void inc_coord(int index) {
    angles[index] += 0.1;
}

// Декремент цветовой компоненты цвета
void dec_coord(int index) {
    angles[index] -= 0.1;
}

int main() {
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
    glGenBuffers(1, &VBO_position);
    glGenBuffers(1, &VBO_color);
    // Вершины кубика
    Vertex triangle[] = {
        { +0.5, +0.5, -0.5 }, { +0.5, -0.5, -0.5 }, { -0.5, -0.5, -0.5 }, { -0.5, +0.5, -0.5 },
        { +0.5, +0.5, -0.5 }, { +0.5, -0.5, -0.5 }, { +0.5, -0.5, +0.5 }, { +0.5, +0.5, +0.5 },
        { +0.5, +0.5, -0.5 }, { +0.5, +0.5, +0.5 }, { -0.5, +0.5, +0.5 }, { -0.5, +0.5, -0.5 },

        { -0.5, -0.5, +0.5 }, { -0.5, -0.5, -0.5 }, { +0.5, -0.5, -0.5 }, { +0.5, -0.5, +0.5 },
        { -0.5, -0.5, +0.5 }, { -0.5, -0.5, -0.5 }, { -0.5, +0.5, -0.5 }, { -0.5, +0.5, +0.5 },
        { -0.5, -0.5, +0.5 }, { +0.5, -0.5, +0.5 }, { +0.5, +0.5, +0.5 }, { -0.5, +0.5, +0.5 }
    };

    // Цвет треугольника
    float colors[][4] = {
        { 0.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 0.0, 1.0 },
        { 1.0, 0.0, 0.0, 1.0 },
        { 1.0, 0.7, 0.0, 1.0 },

        { 0.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 1.0, 1.0 },
        { 0.2, 0.8, 0.8, 1.0 },

        { 0.0, 1.0, 0.0, 1.0 },
        { 0.2, 0.8, 0.8, 1.0 },
        { 0.0, 0.0, 1.0, 1.0 },
        { 1.0, 0.7, 0.0, 1.0 },
        //---------------------------

        { 1.0, 0.15, 0.8, 1.0 },
        { 1.0, 0.0, 0.0, 1.0 },
        { 1.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 1.0, 1.0 },

        { 1.0, 0.15, 0.8, 1.0 },
        { 1.0, 0.0, 0.0, 1.0 },
        { 1.0, 0.7, 0.0, 1.0 },
        { 0.0, 0.0, 1.0, 1.0 },

        { 1.0, 0.15, 0.8, 1.0 },
        { 1.0, 1.0, 1.0, 1.0 },
        { 0.2, 0.8, 0.8, 1.0 },
        { 0.0, 0.0, 1.0, 1.0 },
    };

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors, GL_STATIC_DRAW);
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
    const char* attr_name = "vertexPosition";
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }

    // Вытягиваем ID атрибута цвета
    Attrib_color = glGetAttribLocation(Program, "color");
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib color" << std::endl;
        return;
    }

    // Вытягиваем ID юниформ
    const char* unif_name = "in_angles";
    Unif_angles = glGetUniformLocation(Program, unif_name);
    if (Unif_angles == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
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

    // Включаем массивы атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);

    // Подключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    // Указывая pointer 0 при подключенном буфере, мы указываем что данные в VBO
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);

    // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_QUADS, 0, 36);

    // Отключаем массивы атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);

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
    glDeleteBuffers(1, &VBO_position);
    glDeleteBuffers(1, &VBO_color);
}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}
