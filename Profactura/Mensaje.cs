using System;
using System.Collections.Generic;
using System.Text;

namespace Profactura
{
    public interface Mensaje // creamos la interfaz pública
    {
        void longAlert(string mensaje); // implementamos el mensaje largo 5s
        void shortAlert(string mensaje); // implementamos el mensaje corto 3s

    }
}
