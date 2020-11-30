using System;
namespace Stack_Verificador_Ecuacion
{
    //ISAAC HARO
    //ESTRUCTURA DE DATOS 27/09/2020
    class Stack//CLASE PILA
    {
        private int tope;//TOPE DE TIPO INT
        public Stack(string[] pila)//FUNCION PILA PARA INICIALIZAR TODA LA PILA
        {
            for(int i=0; i < pila.Length; i++)
            {
                pila[i] = "0";//INICIALIZACION EN 0
                tope = -1;
            }
        }
        public int Push(string[] pila,string a)//PUSH 
        {
            int aux2;
            for (tope = 0; tope < a.Length; tope++)
            {
                pila[tope] = a.Substring(tope, 1);//GUARDA LOS DATOS DESDE 0
            }
            aux2 = tope;
            return aux2;
        }
        public string Pop(string[] pila,string a, int aux2)//POP
        {
            string aux="";
            for (tope=aux2; tope > a.Length; tope--)//RETIRA LOS DATOS DEL PUSH EN ORDEN ESPECIFICO
            {
                aux = pila[tope];
                pila[tope] = "0";
            }
            return aux;
        }
        public void Imprimir(string [] pila)//IMPRIME PILA
        {
            for( int i = 0; i <= tope; i++)
            {
                Console.WriteLine(pila[i]);
            }
            Console.WriteLine("La ecuacion esta balanceada correctamente, Esto es todo");
        }
    }
    class Program//CLASE PROGRAM
    {
        static void Main(string[] args)//PROGRAMA PRINCIPAL
        {
            Console.Title="Stack Verificador de ecuaciones";//TITULO DE LA CONSOLA
            Console.BackgroundColor = ConsoleColor.DarkBlue;//COLOR DE LA CONSOLA
            Console.ForegroundColor = ConsoleColor.White;//COLOR DE LA LETRA DE LA CONSOLA
            string a, ingreso, salida="", salida2;//VARIABLES
            bool errores = true;
            int comp1=0,comp2=0,comp3=0,comp4=0,comp5=0,comp6=0,f1=0,f2=0,f3=0,z1=0,z2=0,z3=0,aux=0,cont=0,cont2=0;
            Console.WriteLine("Ingrese la ecuacion a determinar");
            a = Console.ReadLine();
            string[] Longitud_Pila= new string[a.Length];
            Stack Pila = new Stack(Longitud_Pila);//DECLARACION DEL STACK COMO PILA
            for (int i = 0; i < a.Length; i++)//BUCLE PARA DETERMINAR SI LA ECUACION ES CORRECTA
            {
                aux = i;
                ingreso = a.Substring(i, 1);//GUARDAMOS LA POSICION EN UNA VARIABLE
                if (a.Substring(0, 1) == "}" || a.Substring(0, 1) == "]" || a.Substring(0, 1) == ")")
                {
                    Console.WriteLine("Error la ecuacion no esta balanceada");//SI ESTA MAL LA ECUACION SE INFORMARA QUE EXISTE UN ERROR EN LA SINTAXIS
                    break;
                }
                else if (ingreso == "(" || ingreso == "[" || ingreso == "{")//SI EXISTEN LOS TRES TIPOS DE CARACTERES INGRESA AL IF
                {
                    if (ingreso == "(")
                        salida = ")";
                    else if (ingreso == "[")
                        salida = "]";
                    else if (ingreso == "{")
                        salida = "}";
                    Pila.Push(Longitud_Pila, ingreso);//GUARDAMOS LOS DATOS DE INGRESO EN EL PUSH("(","[","{")
                    for (int j = 0; j < a.Length; j++)//VARIFICAMOS SI LOS PARENTESIS, CORCHETES Y LLAVES SE CIERRAN CORRECTAMENTE DENTRO DE LA ECUACION
                    {
                        salida2 = a.Substring(j, 1);//GUARDAMOS LA POSICION EN UNA VARIABLE
                        if (ingreso == "(")//VERIFICA TODOS LOS FACTORES QUE PUEDEN AFECTAR AL CORRECTO FUNCIONAMIENTO DEL PARENTESIS EN LA ECUACION
                        {
                            if (salida2 == "[" || salida2 == "{")
                                comp1 = j;
                            if (salida2 == "}" || salida2 == "]")
                                comp2 = j;
                            if (salida2 == ")")
                            {
                                f1 = j;
                                cont2++;
                            }
                            if (salida2 == "(")
                            {
                                z1 = j;
                                cont++;
                            }
                        }
                        else if (ingreso == "[")//VERIFICA TODOS LOS FACTORES QUE PUEDEN AFECTAR AL CORRECTO FUNCIONAMIENTO DEL CORCHETE EN LA ECUACION
                        {
                            if (salida2 == "(" || salida2 == "{")
                                comp3 = j;
                            if (salida2 == "}" || salida2 == ")")
                                comp4 = j;
                            if (salida2 == "]")
                            {
                                f2 = j;
                                cont2++;
                            }
                            if (salida2 == "[")
                            {
                                z2 = j;
                                cont++;
                            }
                        }
                        else if (ingreso == "{")//VERIFICA TODOS LOS FACTORES QUE PUEDEN AFECTAR AL CORRECTO FUNCIONAMIENTO DE LA LLAVE EN LA ECUACION
                        {
                            if (salida2 == "[" || salida2 == "(")
                                comp5 = j;
                            if (salida2 == ")" || salida2 == "]")
                                comp6 = j;
                            if (salida2 == "}")
                            {
                                f3 = j;
                                cont2++;
                            }
                            if (salida2 == "{")
                            {
                                z3 = j;
                                cont++;
                            }
                        }
                    }
                    if ((comp1 > comp2 || comp3 > comp4 || comp5 > comp6) || (cont % 2 != 0)!=(cont2%2!=0))
                    {
                        Console.WriteLine("Error la ecuacion no esta balanceada");//SI ESTA MAL LA ECUACION SE INFORMARA QUE EXISTE UN ERROR EN LA SINTAXIS
                        break;
                    }
                    else if ((comp1 < f1 && comp2 > f1 && (z1 == 0))|| (comp3 < f2 && comp4 > f2 && (z2 == 0 || z2 > f2)) || (comp5 < f3 && comp6 > f3) && (z3 == 0 || z3 > f3))
                    {
                        Console.WriteLine("Error la ecuacion no esta balanceada");//SI ESTA MAL LA ECUACION SE INFORMARA QUE EXISTE UN ERROR EN LA SINTAXIS
                        break;
                    }
                    else//SI FUNCIONA ESTA CORRECTAMENTE ESTRUCTURADA LA ECUACION REALIZA EL POP
                    {
                        for (int l = i + 1; l < a.Length; l++)
                        {
                            salida2 = a.Substring(l, 1);
                            if (salida2 == salida)
                                Pila.Pop(Longitud_Pila, salida, Pila.Push(Longitud_Pila, ingreso));//POP
                            errores = false;
                        }
                    }
                }
            }
            if (errores == false)//SI NO HAY ERRORES IMPRIMIR PILA
            {
                Pila.Imprimir(Longitud_Pila);//AL FINAL IMPRIME PILA
            }
        }
    }
}
