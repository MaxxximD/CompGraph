#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>
#include "Figure.h"
#include "FigureDraw.h"

int main() {
    //Keyboard:
    //W,A,S,D -> rotate
    // 
	//Num1 -> Blinn_Phong
    //Num2 -> toonShading
    //Num3 -> Minnaert
    // 
    //Z -> cube
    //X -> sphere
    figureDraw("cube.obj", 1);

}


