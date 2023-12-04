var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//Nuevo endpoint
//el string name es para que reciba un parametro 
//name es el parametro que recibimos y lo que imprimimos es hola y la variable quedaria asi la solicitud(https://localhost:7219/hello?name=jeison)
//imprime ("Hola jeison")
app.MapGet("/hello", (string name) => $"Hola {name}");

//Nuevo forma
//en la misma url se envia los parametros name y lastname
// asi la llamamos https://localhost:7219/hellowithname/jose/fernandez
//esto imprime Holajeisson triana

app.MapGet("/Hellowithname/{name}/{lastname}",
    (string name, string lastname) => $"Hola {name} {lastname}");

// Creamos un endpoint que sea asincrónico
app.MapGet("/response", async () =>
{
    // Creamos una instancia de HttpClient, que se utiliza para realizar solicitudes HTTP
    HttpClient client = new HttpClient();

    // Realizamos una solicitud GET asincrónica a la URL especificada
    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");

    // Aseguramos que la solicitud sea exitosa (estatus HTTP 200-299)
    response.EnsureSuccessStatusCode();

    // Leemos el contenido de la respuesta como una cadena de texto de manera asincrónica
    string leerRespuesta = await response.Content.ReadAsStringAsync();

    // Devolvemos la respuesta leída
    return leerRespuesta;
});

app.Run();
