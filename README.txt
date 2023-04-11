Programa simple de emulación de un cajero automático sin conexión a base de datos.
Datos de inicio de sesión por defecto: admin - password.
Valor monetario por defecto: Q. 4,000.00.

Se implentaron procedimientos para validar el formato de un TextBox mientras el usuario escribe. 
Uso de los eventos:

-KeyPress(para bloquear las letras)

-KeyDown(controla el punto decimal cuando el usuario entra por primera vez al TextBox y no ingresa numeros enteros)

-Click(hace que el selector se posicione por primera vez antes del punto decimal)

-KeyUp(Aca se validan todos los valores ingresados y se controlan los datos ingresados por error)