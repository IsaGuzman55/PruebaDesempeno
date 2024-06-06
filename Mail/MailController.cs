using System.Text;
using System.Text.Json;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Utils;

public class MailController{
    public async void EnviarCorreo(string userEmail, string studentNames, DateOnly dateCreate, string studentCourse, string enrollmentStatus){

        /* Inicializar variable, URL de destino para la solicitud POST de la API Mailsersend*/
        string url = "https://api.mailersend.com/v1/email";

        /* Token de autorizacion para la solicitud: */
        string tokenEmail = "mlsn.ba0885ea6c913ce138e5401870d058da2905115fb3a1c7fea168c7365e697e8b";

        /* Se crea una instancia de la clase Email para contener el mensaje */
        var emailMessage = new Email{
            from = new From {email = "MS_y99CNE@trial-yzkq340o1zk4d796.mlsender.net"},
            to = [
                new To {email = userEmail}
            ],
            subject = "Enrollment Information",
            text = $"{studentNames}, you enrollment was create, this is the information of the respective enrollment:  Student - {studentNames}, Date - {dateCreate}, Course - {studentCourse}, Status of the enrollment - {enrollmentStatus}. good day!",
            html = $"{studentNames}, you enrollment was create, this is the information of the respective enrollment:  Student - {studentNames}, Date - {dateCreate}, Course - {studentCourse}, Status of the enrollment - {enrollmentStatus}. good day!"
        };


        /* Serializar el objeto emailMessage en formato JSON: */
        string jsonBody = JsonSerializer.Serialize(emailMessage);

        /* Crear un objeto HTTPClient para realuzar la solicitud HTTP */
        using(HttpClient client = new HttpClient()){
            /* Configurar el encabezado de Authorization para indicar el token de autorizacion */
            /* client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenEmail); */
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenEmail}");

            /* Crear el contenido de la silicitus POST como StringContent: */
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            /* Realizar la solicitud POST a la URL indicada: */
            HttpResponseMessage response = await client.PostAsync(url,content);

            /* Se confirma si la solicitud fue éxitoso (codigo de estado: 200 - 209) */
            if(response.IsSuccessStatusCode){
                Console.WriteLine($"Estado de la solicitud: {response.StatusCode}");
            }
            else{
                /* Si la solicitud no sue éxitosa, se muestra el estado de la solicitud:  */
                Console.WriteLine($"La solicitud falló con el código de estado: {response.StatusCode}");
            }

        }



    } 
}