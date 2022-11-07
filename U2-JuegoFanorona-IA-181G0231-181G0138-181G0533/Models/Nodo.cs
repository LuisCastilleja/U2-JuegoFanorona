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
// Reglas
//1.- Los jugadores se turnan para mover ficha, empezando el blanco.
//2.- Hay dos tipos de movimiento: normal y de captura. Un movimiento "normal" (en el que no se produce ninguna captura), se denomina paika.
//    Un movimiento paika consiste en mover una ficha por una línea hasta una intersección adyacente.
//3.- Los movimientos de captura son obligatorios, y tienen preferencia sobre los movimientos paika.
//4.- Una captura implica la eliminación de una o más fichas del oponente, en una de estas dos maneras:
//    Acercamiento: consiste en mover una ficha a una intersección cercana a la ficha del oponente;
//    dicha intersección debe estar en la continuación de la línea de movimiento de la ficha que realiza la captura.
//    Alejamiento: la ficha que realiza la captura se desplaza a otra intersección desde una intersección adyacente
//    a una ficha del oponente, alejándose de la ficha del rival pero manteniendo al mismo tiempo una línea de
//    movimiento que permita capturarla.
//5.- Cuando una ficha del rival es capturada, todas las fichas situadas en la misma línea de movimiento empleada en
//    la captura pueden ser capturadas, pero solo si no hay espacios vacíos o fichas propias de por medio.
//6.- Un movimiento de captura por acercamiento no puede simultanearse con un movimiento de captura por alejamiento,
//    y viceversa; el jugador debe escoger uno de los dos.
//7.- Al igual que en las damas inglesas, la ficha que captura puede realizar capturas sucesivas, con las siguientes restricciones:
//    La ficha no puede colocarse en la misma posición dos veces.
//    No está permitido mover dos veces seguidas en la misma dirección (para hacer una captura por alejamiento en
//    primer lugar, y luego una captura por acercamiento), como parte de una secuencia de captura.
//    Sin embargo, la continuación de la secuencia de captura es opcional, al contrario que en las damas inglesas.
// ​
//8.- El juego termina cuando un oponente captura todas las fichas del rival.
//    Si ningún jugador puede lograr esto (por ejemplo, si el juego llega a una situación en la que ningún jugador
//    puede atacar a otro sin debilitar su propia posición), entonces la partida queda en tablas.
    }
}
