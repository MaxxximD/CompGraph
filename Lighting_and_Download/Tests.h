#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>
#include "Figure.h"

void ParseTest(Figure* f) {
    const int k_v = f->vertices.size();//кол-во вершин
    const int k_n = f->normals.size(); //кол-во нормалей
    const int k_t = f->textures.size(); //кол-во текстур
    const int k_f = f->faces.size(); //кол-во граней
    const int k_f_2 = f->faces[0].size(); //кол-во граней_2 f (3/4/1 4/3/1 2/2/1 1/1/1) -> 4

    std::cout << std::endl;
    //Check vertices
    std::cout << "Check vertices:" << std::endl;

    for (int i = 0; i < k_v; i++) {
        printf("%f ", f->vertices[i].x);
        printf("%f ", f->vertices[i].y);
        printf("%f\n", f->vertices[i].z);
    }
    std::cout << std::endl;

    //Check normals
    std::cout << "Check normals:" << std::endl;

    for (int i = 0; i < k_n; i++) {
        printf("%f ", f->normals[i].x);
        printf("%f ", f->normals[i].y);
        printf("%f\n", f->normals[i].z);
    }
    std::cout << std::endl;

    //Check textures
    std::cout << "Check textures:" << std::endl;

    for (int i = 0; i < k_t; i++) {
        printf("%f ", f->textures[i].x);
        printf("%f ", f->textures[i].y);
        printf("%f\n", f->textures[i].z);
    }
    std::cout << std::endl;


    //Check faces
    std::cout << "Check faces (digit - 1. Example: 3/4/1 -> 2/3/0):" << std::endl;

    for (int i = 0; i < k_f; i++) {
        for (int j = 0; j < k_f_2; j++) {
            printf("%d/", f->faces[i][j].v);
            printf("%d/", f->faces[i][j].vn);
            printf("%d ", f->faces[i][j].vt);
        }
        std::cout << std::endl;
    }
}

void ArrayTest(GLfloat* arr, int k, int length) {
    
    std::cout << "------------------" << std::endl;
    
    int j = 0;

    for (int i = 0; i < k; i++) {
        std::cout << arr[j] << " ";
        std::cout << arr[j + 1] << " ";
        std::cout << arr[j + 2] << std::endl;
        j += 3;
    }
}

void ArrayTest(GLuint* arr, int k, int length) {

    std::cout << "------------------" << std::endl;

    int j = 0;

    for (int i = 0; i < k; i++) {
        std::cout << arr[j] << " ";
        std::cout << arr[j + 1] << " ";
        std::cout << arr[j + 2] << " ";
        std::cout << arr[j + 3] << std::endl;
        j += 4;
    }
}