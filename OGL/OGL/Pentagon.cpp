#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>
void Drawpentagon() {
    int v;
    float pent[5][2], ang, da = 6.2832 / 5.0;
    for (v = 0; v < 5; v++) {
        ang = v * da;
        pent[v][0] = cos(ang);
        pent[v][1] = sin(ang);
    }
    glBegin(GL_POLYGON);
    for (v = 0; v < 5; v++)  glVertex2fv(pent[v]);
    glColor3ub(255, 0, 0);
    glEnd();
}