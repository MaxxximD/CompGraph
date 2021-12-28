#include <iostream>
#include <vector>
#include <string>
#include <fstream>

//Вершина
struct Vertex
{
	GLfloat x;
	GLfloat y;
	GLfloat z;
};

struct Figure_Vertex {
	GLuint v;  //vertice index
	GLuint vt; //texture index
	GLuint vn; //normal index
};

class Figure {
public:
	std::vector<Vertex> vertices;
	std::vector<Vertex> normals;
	std::vector<Vertex> textures;
	std::vector<std::vector<Figure_Vertex>> faces;

	//Разделение строки по разделителю
	std::vector<std::string> split(std::string s, std::string delimiter) {
		std::vector<std::string> res;

		size_t pos = 0;
		std::string token;

		while ((pos = s.find(delimiter)) != std::string::npos) {
			token = s.substr(0, pos);
			res.push_back(token);
			s.erase(0, pos + delimiter.length());
		}
		res.push_back(s);
		return res;
	}

	Figure(const std::string& path) {
		std::string str;

		std::ifstream in(path); // открываем файл для чтения
		if (in.is_open())
		{
			while (getline(in, str))
			{
				if (str[0] == 'v') {
					std::vector<std::string> s = split(str, " ");
					if (str[1] == ' ') {		//встретили v
						vertices.push_back({ std::stof(s[1]), std::stof(s[2]) ,std::stof(s[3]) });
					}
					else if (str[1] == 'n') {	//встретили vn
						normals.push_back({ std::stof(s[1]), std::stof(s[2]) ,std::stof(s[3]) });
					}
					else if (str[1] == 't') {	//встретили vt
						textures.push_back({ std::stof(s[1]), std::stof(s[2]) ,std::stof(s[3]) });
					}
				}
				else if (str[0] == 'f') {

					std::vector<std::string> s = split(str, " ");
					std::vector<Figure_Vertex> v;

					//for (int i = 0; i < 4; i++) {
					for (int i = 0; i < 3; i++) {
						std::vector<std::string> s_2 = split(s[i + 1], "/");
						v.push_back({ (GLuint)std::stof(s_2[0]) - 1, (GLuint)std::stof(s_2[1]) - 1 , (GLuint)std::stof(s_2[2]) - 1 });
					}
					faces.push_back(v);
				}
			}
		}
		in.close();     // закрываем файл
	}
};

//Возвращает значения вершин
std::vector<std::vector<float>> get_vertices(Figure* f) {
	int facesSize = f->faces.size();
	int curSize = 3;
	std::vector<std::vector<float>> res = std::vector<std::vector<float>>(facesSize * curSize);

	for (int i = 0; i < facesSize; i++) {
		for (int j = 0; j < curSize; j++)
		{
			Vertex curVert = f->vertices[f->faces[i][j].v];
			res[curSize * i + j] = { curVert.x, curVert.y, curVert.z };
		}
	}
	return res;
}

//Возвращает значения текстур
std::vector<std::vector<float>> get_textures(Figure* f) {
	int facesSize = f->faces.size();
	int curSize = 3;
	std::vector<std::vector<float>> res = std::vector<std::vector<float>>(facesSize * curSize);
	for (int i = 0; i < facesSize; i++) {
		for (int j = 0; j < curSize; j++)
		{
			Vertex curText = f->textures[f->faces[i][j].vt];
			res[curSize * i + j] = { curText.x, curText.y, curText.z };
		}
	}
	return res;
}

//Возвращает значения нормалей
std::vector<std::vector<float>> get_normals(Figure* f) {
	int facesSize = f->faces.size();
	int curSize = 3;
	std::vector<std::vector<float>> res = std::vector<std::vector<float>>(facesSize * curSize);

	for (int i = 0; i < facesSize; i++) {
		for (int j = 0; j < curSize; j++)
		{
			Vertex curNorm = f->normals[f->faces[i][j].vn];
			res[curSize * i + j] = { curNorm.x, curNorm.y, curNorm.z };
		}
	}
	return res;
}

//Возвращение значений вершин
std::vector<float> get_Vert2(Figure* f) {
	int curSize = 3;

	std::vector<std::vector<float>> v = get_vertices(f);

	std::vector<float> res;

	for (int i = 0; i < v.size(); i++) {
		for (int j = 0; j < curSize; j++) {
			res.push_back(v[i][j]);
		}
	}
	return res;
}

//Возвращение значений нормалей
std::vector<float> get_Norm2(Figure* f) {
	int curSize = 3;

	std::vector<std::vector<float>> v = get_normals(f);

	std::vector<float> res;

	for (int i = 0; i < v.size(); i++) {
		for (int j = 0; j < curSize; j++) {
			res.push_back(v[i][j]);
		}
	}
	return res;
}

//Возвращение значений нормалей
std::vector<float> get_Text2(Figure* f) {
	int curSize = 3;

	std::vector<std::vector<float>> v = get_textures(f);

	std::vector<float> res;

	for (int i = 0; i < v.size(); i++) {
		for (int j = 0; j < curSize; j++) {
			res.push_back(v[i][j]);
		}
	}
	return res;
}

#pragma once
