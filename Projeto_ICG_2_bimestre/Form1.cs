/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 28/05/2025
 * Autores do Projeto: Davi Souza Ribeiro - 50230158
 *                     Gabriel Leandro Paiva - 50230163
 *
 * Turma: 3º ano F
 * Atividade Proposta em aula
 * Observação: nenhuma
 * 
 * 
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto_ICG_2_bimestre
{
    public partial class Form1 : Form
    {
        int r = 0;
        int g = 0;
        int b = 0;
        float coordenadaX1 = 0;
        float coordenadaY1 = 0;
        float coordenadaX2 = 0;
        float coordenadaY2 = 0;
        float coordenadaX3 = 0;
        float coordenadaY3 = 0;
        float coordenadaX4 = 0;
        float coordenadaY4 = 0;
        float coordenadaX5 = 0;
        float coordenadaY5 = 0;
        float valorEspessura = 0;
        bool permitidoParaSalvar = false;
        bool confirmacaoParaPintarPentagono = false;
        bool confirmacaoParaPintarTriangulo = false;
        bool confirmacaoParaPintarQuadrado = false;
        bool confirmacaoParaPintarReta = false;
        bool confirmacaoParaPintarLosango = false;
        bool desenharTriangulo = false;
        bool desenharLinha = false;
        bool desenharLosango = false;
        bool desenharReta = false;
        bool desenharPentagono = false;
        bool desenharQuadrado = false;
        int cliqueContador = 1;
        bool foiClicadoAntes = false;
        Color corDoFundo;
        int espessuraGlobal = 0;

        int contadorQ = 1;
        int contadorP = 1;
        int contadorL = 1;
        int contadorT = 1;
        int contadorR = 1;

        public Form1()
        {
            InitializeComponent();
        }

        public void gravarDadosNoArquivo(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, String figura, String estiloLinha)
        {
            String texto = "";
            if (figura == "reta")
            {
                texto = "\nX===================================================X\n" + contadorR + "ª Reta: \n x1 = " + x0 + "\n x2 = " + x1 + "\n +--------------------------------+ \n y1 = " + y0 + "\n y2 = " + y1;
                contadorR++;
            }
            if (figura == "quadrado")
            {
                float coordenada1 = x0;
                float coordenada2 = y0;
                float coordenada3 = x0;
                float coordenada4 = y1;
                float coordenada5 = x1;
                float coordenada6 = y1;
                float coordenada7 = x1;
                float coordenada8 = y0;
                texto = "\nX===================================================X\n" + contadorQ + "º Quadrado: \n x1 = " + coordenada1 + "\n x2 = " + coordenada3 + "\n x3 = " + coordenada5 + "\n x4 = " + coordenada7 + "\n +--------------------------------+ \n y1 = " + coordenada2 + "\n y2 = " + coordenada4 + "\n y3 = " + coordenada6 + "\n y4 = " + coordenada8;
                contadorQ++;
            }
            if (figura == "pentagono")
            {
                texto = "\nX===================================================X\n" + contadorP + "º Pentagono: \n x1 = " + x0 + "\n x2 = " + x1 + "\n x3 = " + x2 + "\n x4 = " + x3 + "\n x5 = " + x4 + "\n +--------------------------------+ \n y1 = " +
                    y0 + "\n y2 = " + y1 + "\n y3 = " + y2 + "\n y4 = " + y3 + "\n y5 = " + y4;
                contadorP++;
            }
            if (figura == "losango")
            {
                texto = "\nX===================================================X\n" + contadorL + "º Losango: \n x1 = " + x0 + "\n x2 = " + x1 + "\n x3 = " + x2 + "\n x4 = " + x3 + "\n +--------------------------------+ \n y1 = " +
                y0 + "\n y2 = " + y1 + "\n y3 = " + y2 + "\n y4 = " + y3;
                contadorL++;
            }
            if (figura == "triangulo")
            {
                texto = "\nX===================================================X\n" + contadorT + "º Triângulo: \n x1 = " + x0 + "\n x2 = " + x1 + "\n x3 = " + x2 + "\n +--------------------------------+ \n y1 = " +
                y0 + "\n y2 = " + y1 + "\n y3 = " + y2;
                contadorT++;
            }
            File.AppendAllText(@"C:\Arquivos\dados.dat", texto + "\n +--------------------------------+ \n Cores: RGB(" + r + ", " + g + ", " + b + ") \n Estilo da linha: " + estiloLinha + "\n Espessura: " + espessuraGlobal + "px");
        }

        public void losango(PaintEventArgs e, float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, Pen caneta)
        {
            pintaLinha(e, x0, y0, x1, y1, caneta);
            pintaLinha(e, x1, y1, x2, y2, caneta);
            pintaLinha(e, x2, y2, x3, y3, caneta);
            pintaLinha(e, x3, y3, x0, y0, caneta);
        }

        public void pentagono(PaintEventArgs e, float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, Pen caneta)
        {
            pintaLinha(e, x0, y0, x1, y1, caneta);
            pintaLinha(e, x1, y1, x2, y2, caneta);
            pintaLinha(e, x2, y2, x3, y3, caneta);
            pintaLinha(e, x3, y3, x4, y4, caneta);
            pintaLinha(e, x4, y4, x0, y0, caneta); 
        }

        public void pintaLinha(PaintEventArgs e, float max_x, float max_y, float min_x, float min_y, Pen caneta)
        {
            e.Graphics.DrawLine(caneta, min_x, min_y, max_x, max_y);
        }

        public Color cores(int R, int G, int B)
        {
            Color cor = new Color();
            cor = Color.FromArgb(R, G, B);
            return cor;
        }

        public Pen estilo_linha(float[] estilo, Pen cor)
        {
            Pen caneta = cor;
            caneta.DashPattern = estilo;
            return caneta;
        }

        public int espessura()
        {
            int espessura = 0;
            if (listBox1.GetSelected(0))
            {
                espessura = 1;
                espessuraGlobal = espessura;
            }
            else if (listBox1.GetSelected(1))
            {
                espessura = 3;
                espessuraGlobal = espessura;
            }
            else if (listBox1.GetSelected(2))
            {
                espessura = 5;
                espessuraGlobal = espessura;
            }
            else if (listBox1.GetSelected(3))
            {
                espessura = 8;
                espessuraGlobal = espessura;
            }
            return espessura;
        }
        public Pen canetaEspessura(PaintEventArgs e, int R, int G, int B, int espessura)
        {
            Color cor = cores(R, G, B);
            Pen caneta = new Pen(cor, espessura);
            return caneta;    
        }

        public void triangulo(PaintEventArgs e, float x0, float y0, float x1, float y1, float x2, float y2, Pen caneta)
        {
            pintaLinha(e, x0, y0, x1, y1, caneta);
            pintaLinha(e, x1, y1, x2, y2, caneta);
            pintaLinha(e, x2, y2, x0, y0, caneta);

        }

        public void quadrado(PaintEventArgs e, float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, Pen caneta)
        {
            pintaLinha(e, x0, y0, x1, y1, caneta); 
            pintaLinha(e, x1, y1, x2, y2, caneta); 
            pintaLinha(e, x2, y2, x3, y3, caneta); 
            pintaLinha(e, x3, y3, x0, y0, caneta); 
        }


        private void button19_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float[] solida = { 1 };
            float[] tracejada = { 10, 5 };
            float[] tracoPonto = { 10, 5, 1, 5 };
            float[] tracoDoisPontos = { 10, 5, 1, 5, 1, 5 };
            float[] pontilhada = { 1, 5 };
            String estiloLinha = "";
            if (confirmacaoParaPintarReta == true)
            {
                if (listBox2.GetSelected(0))
                {
                    pintaLinha(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, estilo_linha(solida, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "solida";
                }
                else if (listBox2.GetSelected(1))
                {
                    pintaLinha(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, estilo_linha(tracejada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "tracejada";
                }
                else if (listBox2.GetSelected(2))
                {
                    pintaLinha(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, estilo_linha(pontilhada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "pontilhada";
                }
                else if (listBox2.GetSelected(3))
                {
                    pintaLinha(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, estilo_linha(tracoDoisPontos, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com dois pontos";
                }
                else if (listBox2.GetSelected(4))
                {
                    pintaLinha(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, estilo_linha(tracoPonto, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com um ponto";
                }
                if (permitidoParaSalvar)
                {
                    gravarDadosNoArquivo(coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, "reta", estiloLinha);
                }
                confirmacaoParaPintarReta = false;
            }
            if (confirmacaoParaPintarQuadrado == true)
            {
                if (listBox2.GetSelected(0))
                {
                    quadrado(e, coordenadaX1, coordenadaY1, coordenadaX1, coordenadaY2, coordenadaX2, coordenadaY2, coordenadaX2, coordenadaY1, estilo_linha(solida, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "solida";
                }
                else if (listBox2.GetSelected(1))
                {
                    quadrado(e, coordenadaX1, coordenadaY1, coordenadaX1, coordenadaY2, coordenadaX2, coordenadaY2, coordenadaX2, coordenadaY1, estilo_linha(tracejada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "tracejada";
                }
                else if (listBox2.GetSelected(2))
                {
                    quadrado(e, coordenadaX1, coordenadaY1, coordenadaX1, coordenadaY2, coordenadaX2, coordenadaY2, coordenadaX2, coordenadaY1, estilo_linha(pontilhada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "pontilhada";
                }
                else if (listBox2.GetSelected(3))
                {
                    quadrado(e, coordenadaX1, coordenadaY1, coordenadaX1, coordenadaY2, coordenadaX2, coordenadaY2, coordenadaX2, coordenadaY1, estilo_linha(tracoDoisPontos, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com dois pontos";
                }
                else if (listBox2.GetSelected(4))
                {
                    quadrado(e, coordenadaX1, coordenadaY1, coordenadaX1, coordenadaY2, coordenadaX2, coordenadaY2, coordenadaX2, coordenadaY1, estilo_linha(tracoPonto, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com um ponto";
                }
                if (permitidoParaSalvar)
                {
                    gravarDadosNoArquivo(coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, "quadrado", estiloLinha);
                }
                    confirmacaoParaPintarQuadrado = false;
            }
            if (confirmacaoParaPintarTriangulo == true)
            {
                if (listBox2.GetSelected(0))
                {
                    triangulo(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, estilo_linha(solida, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "solida";
                }
                else if (listBox2.GetSelected(1))
                {
                    triangulo(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, estilo_linha(tracejada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "tracejada";
                }
                else if (listBox2.GetSelected(2))
                {
                    triangulo(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, estilo_linha(pontilhada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "pontilhada";
                }
                else if (listBox2.GetSelected(3))
                {
                    triangulo(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, estilo_linha(tracoDoisPontos, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com dois pontos";
                }
                else if (listBox2.GetSelected(4))
                {
                    triangulo(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, estilo_linha(tracoPonto, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com um ponto";
                }
                if (permitidoParaSalvar)
                {
                    gravarDadosNoArquivo(coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, "triangulo", estiloLinha);
                }
                    confirmacaoParaPintarTriangulo = false;
            }
            if (confirmacaoParaPintarPentagono == true)
            {
                if (listBox2.GetSelected(0))
                {
                    pentagono(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, estilo_linha(solida, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "solida";
                }
                else if (listBox2.GetSelected(1))
                {
                    pentagono(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, estilo_linha(tracejada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "tracejada";
                }
                else if (listBox2.GetSelected(2))
                {
                    pentagono(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, estilo_linha(pontilhada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "pontilhada";
                }
                else if (listBox2.GetSelected(3))
                {

                    pentagono(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, estilo_linha(tracoDoisPontos, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com dois pontos";
                }
                else if (listBox2.GetSelected(4))
                {
                    pentagono(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, estilo_linha(tracoPonto, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com um ponto";
                }
                if (permitidoParaSalvar)
                {
                    gravarDadosNoArquivo(coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, "pentagono", estiloLinha);
                }
                    confirmacaoParaPintarPentagono = false;
            }
            if (confirmacaoParaPintarLosango == true)
            {
                if (listBox2.GetSelected(0))
                {
                    losango(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, estilo_linha(solida, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "solida";
                }
                else if (listBox2.GetSelected(1))
                {
                    losango(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, estilo_linha(tracejada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "tracejada";
                }
                else if (listBox2.GetSelected(2))
                {
                    losango(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, estilo_linha(pontilhada, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "pontilhada";
                }
                else if (listBox2.GetSelected(3))
                {
                    losango(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, estilo_linha(tracoDoisPontos, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com dois pontos";
                }
                else if (listBox2.GetSelected(4))
                {
                    losango(e, coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, estilo_linha(tracoPonto, canetaEspessura(e, r, g, b, espessura())));
                    estiloLinha = "traço com um ponto";
                }
                if (permitidoParaSalvar)
                {
                    gravarDadosNoArquivo(coordenadaX1, coordenadaY1, coordenadaX2, coordenadaY2, coordenadaX3, coordenadaY3, coordenadaX4, coordenadaY4, coordenadaX5, coordenadaY5, "losango", estiloLinha);
                }
                    confirmacaoParaPintarLosango = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r = 0;
            b = 0;
            g = 0;
            Invalidate();
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            r = 144;
            g = 47;
            b = 55;
            Invalidate();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            r = 128;
            g = 128;
            b = 128;
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 0;
            b = 0;
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 140;
            b = 0;
            Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 0;
            Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            r = 154;
            g = 205;
            b = 50;
            Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            r = 173;
            g = 216;
            b = 230;
            Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 0;
            b = 255;
            Invalidate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            r = 80;
            g = 0;
            b = 200;
            Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 255;
            b = 255;
            Invalidate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            r = 211;
            g = 211;
            b = 211;
            Invalidate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            r = 212;
            g = 171;
            b = 33;
            Invalidate();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 0;
            b = 127;
            Invalidate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            r = 255;
            g = 215;
            b = 0;
            Invalidate();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            r = 220;
            g = 212;
            b = 155;
            Invalidate();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            r = 0;
            g = 255;
            b = 0;
            Invalidate();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            r = 176;
            g = 224;
            b = 230;
            Invalidate();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            r = 100;
            g = 149;
            b = 237;
            Invalidate();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            r = 123;
            g = 104;
            b = 238;
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (desenharLinha == true)
            {
                if (cliqueContador == 1)
                {
                    coordenadaX1 = e.X;
                    coordenadaY1 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 2)
                {
                    coordenadaX2 = e.X;
                    coordenadaY2 = e.Y;
                    confirmacaoParaPintarReta = true; 
                    cliqueContador = 1; 
                }
            }
            if (desenharQuadrado == true)
            {
                if (cliqueContador == 1)
                {
                    coordenadaX1 = e.X;
                    coordenadaY1 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 2)
                {
                    coordenadaX2 = e.X;
                    coordenadaY2 = e.Y;
                    confirmacaoParaPintarQuadrado = true;
                    cliqueContador = 1; 
                }
            }

            if (desenharTriangulo == true)
            {
                if (cliqueContador == 1)
                {
                    coordenadaX1 = e.X;
                    coordenadaY1 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 2)
                {
                    coordenadaX2 = e.X;
                    coordenadaY2 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 3)
                {
                    coordenadaX3 = e.X;
                    coordenadaY3 = e.Y;
                    confirmacaoParaPintarTriangulo = true;
                    cliqueContador = 1;
                }
            }
            if (desenharPentagono == true)
            {
                if (cliqueContador == 1)
                {
                    coordenadaX1 = e.X;
                    coordenadaY1 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 2)
                {
                    coordenadaX2 = e.X;
                    coordenadaY2 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 3)
                {
                    coordenadaX3 = e.X;
                    coordenadaY3 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 4)
                {
                    coordenadaX4 = e.X;
                    coordenadaY4 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 5)
                {
                    coordenadaX5 = e.X;
                    coordenadaY5 = e.Y;
                    confirmacaoParaPintarPentagono = true;
                    cliqueContador = 1;
                }
            }
            if (desenharLosango == true)
            {
                if (cliqueContador == 1)
                {
                    coordenadaX1 = e.X;
                    coordenadaY1 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 2)
                {
                    coordenadaX2 = e.X;
                    coordenadaY2 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 3)
                {
                    coordenadaX3 = e.X;
                    coordenadaY3 = e.Y;
                    cliqueContador++;
                }
                else if (cliqueContador == 4)
                {
                    coordenadaX4 = e.X;
                    coordenadaY4 = e.Y;
                    confirmacaoParaPintarLosango = true;
                    cliqueContador = 1;
                }
            }
            Invalidate();
        }

      
        private void button22_Click(object sender, EventArgs e)
        {
            desenharQuadrado = false;
            desenharLinha = true;
            desenharPentagono = false;
            desenharTriangulo = false;
            desenharLosango = false;
            cliqueContador = 1; 
        }

        private void button27_Click(object sender, EventArgs e)
        {
            desenharTriangulo = false;
            desenharLinha = false;
            desenharPentagono = false;
            desenharQuadrado = true;
            desenharLosango = false;
            cliqueContador = 1; 
        }

        private void button24_Click(object sender, EventArgs e)
        {
            desenharTriangulo = true;
            desenharLinha = false;
            desenharQuadrado = false;
            desenharPentagono = false;
            desenharLosango = false;
            cliqueContador = 1; 
        }

        private void button25_Click(object sender, EventArgs e)
        {
            desenharTriangulo = false;
            desenharLinha = false;
            desenharQuadrado = false;
            desenharPentagono = true;
            desenharLosango = false;
            cliqueContador = 1; 
        }

        private void button23_Click(object sender, EventArgs e)
        {
            desenharTriangulo = false;
            desenharLinha = false;
            desenharQuadrado = false;
            desenharPentagono = false;
            desenharLosango = true;
            cliqueContador = 1; 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button21_Click(object sender, EventArgs e)
        {
            permitidoParaSalvar = true;
        }
    }
}