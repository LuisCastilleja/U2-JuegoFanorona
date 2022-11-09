using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace U2_JuegoFanorona_IA_181G0231_181G0138_181G0533.Models
{
    public class Nodo
    {
        public string State { get; set; } = "220000111";
        public List<Nodo> Children { get; set; } = new List<Nodo>();
        public int Value { get; set; }
        public int Whites { get; set; } = 4;
        public int Blacks { get; set; } = 4;
        public int Turn { get; set; } = 1;
        private bool maximizing = false;
        private int openWhites;
        private int openBlacks;
        //Matriz multidimensional
        private static readonly int[,] lines =
            new int[,] {
                //Matriz bidimensional de 3 filas y 3 columnas
                //El numero 2 representa una ficha negra y el numero 1 represena una ficha blanca y el numero 0 es vacio.
            { 2,2,2},
            { 2,0,1},
            { 1,1,1}
            };
        public bool WinnerWhitesOrBlacks(int whites, int blacks)
        {
           if(whites == 0)
            {
                return true;
            }
           else if(blacks == 0)
            {
                return true;
            }
            return false;
        }
        
        public void ChildrenGenerate(int turn, int depth)
        {
            Turn = turn;
            for (int i = 0; i < 9; i++)
            {
                if (State[i] == '0')
                {
                    var arrayState = State.ToArray();
                    //Pendiente eliminar en la posicion que estaba la pieza que se movio y ver si hay piezas del otro 
                    //Color enfrente, en diagonal y ver como llego para ver si se elimina  y restar a blancas o a negras
                    arrayState[i] = char.Parse(Turn.ToString());
                    var estadoHijo = new string(arrayState);
                    Nodo son = new Nodo()
                    {
                        State = new string(arrayState)
                    };
                    if (depth > 1 && !WinnerWhitesOrBlacks(Whites, Blacks))
                    {
                        //1 es blancas y 2 negras
                        son.ChildrenGenerate((Turn == 1) ? Turn = 2 : Turn=1, depth - 1);
                        //Empieza el maximizin en false porque se empieza minimizando
                        MinMax(depth, maximizing);
                    }
                    if (maximizing == true)
                    {
                        maximizing = false;
                    }
                    else
                    {
                        maximizing = true;
                    }
                    Children.Add(son);

                }
            }
        }
        public void ValueCalculate(int turno)
        {
            if (FinalGame)
            {
                Value = (WinnerWhitesOrBlacks(Whites, Blacks)) ? int.MaxValue : int.MinValue;
            }
            else
            {
                if(turno == 1)
                {
                     openWhites = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        //El primer numero en la matriz te dice el conjunto de elementos
                        //El segundo numero en la matriz te dice en que posicion del conjunto de elementos
                        if (State[Nodo.lines[i, 0]] == '0' || State[Nodo.lines[i, 1]] == '0' || State[Nodo.lines[i, 2]] == '0')
                        {
                            openWhites += 1;
                        }
                        else
                        {
                            openWhites += 0;
                        }
                    }
                    Value = openWhites - openBlacks;
                    Turn = 2;
                    openWhites = 0;
                    openBlacks = 0;
                }
                else
                {
                     openBlacks = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (State[Nodo.lines[i, 0]] == '0' || State[Nodo.lines[i, 1]] == '0' || State[Nodo.lines[i, 2]] == '0')
                        {
                            openBlacks += 1;
                        }
                        else
                        {
                            openBlacks += 0;
                        }
                    }
                    Value = openBlacks - openWhites;
                    Turn = 1;
                    openWhites = 0;
                    openBlacks = 0;
                }
            }
        }
        public override string ToString()
        {
            return State.ToString();
        }
        public bool FinalGame
        {
            get { return WinnerWhitesOrBlacks(Whites, Blacks); }
        }
        public int MinMax(int depth, bool maximizingToPlayer)
        {
            if (depth == 0 || FinalGame)
            {
                ValueCalculate(Turn);
                return Value;
            }
            else
            {
                if (maximizingToPlayer)
                {
                    int value = int.MinValue;
                    foreach (var hijo in Children)
                    {
                        Value = Math.Max(Value, MinMax(depth - 1, !maximizingToPlayer));
                    }
                    Value = value;
                    Turn = 1;
                    return value;
                }
                else
                {
                    int value = int.MaxValue;
                    foreach (var son in Children)
                    {
                        value = Math.Min(value, son.MinMax(depth - 1, maximizingToPlayer));
                    }
                    Value = value;
                    Turn = 2;
                    return value;
                }
            }
        }
    }
}
