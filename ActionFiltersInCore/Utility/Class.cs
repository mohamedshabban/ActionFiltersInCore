//using System.Security.Claims;
//using System;
//using System.IO;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web.Http;
//namespace ActionFiltersInCore.Utility
//{
//    public class LoggingHandler : DelegatingHandler
//    {
//        private readonly string logFolderPath;

//        public LoggingHandler()
//        {
//            // Set the log folder path on the desktop
//            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//            logFolderPath = Path.Combine(desktopPath, "RequestLogs");

//            // Create the log folder if it doesn't exist
//            if (!Directory.Exists(logFolderPath))
//            {
//                Directory.CreateDirectory(logFolderPath);
//            }
//        }

//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            // Log the request
//            await LogRequest(request);

//            // Call the inner handler to process the request
//            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

//            // Log the response
//            await LogResponse(response);

//            return response;
//        }

//        private async Task LogRequest(HttpRequestMessage request)
//        {
//            // Check if the user is authenticated
//            if (request.GetRequestContext().Principal.Identity.IsAuthenticated)
//            {
//                // Get the subscriber ID claim
//                var subscriberIdClaim = (request.GetRequestContext().Principal as ClaimsPrincipal)?.FindFirst("subscriberId");

//                if (subscriberIdClaim != null)
//                {
//                    string subscriberId = subscriberIdClaim.Value;

//                    // Create a file with the subscriber ID and current date as the name
//                    string fileName = $"{subscriberId}_{DateTime.Now:dd.MM.yyyy}.txt";
//                    string filePath = Path.Combine(logFolderPath, fileName);

//                    // Log the request to the file
//                    using (StreamWriter writer = File.AppendText(filePath))
//                    {
//                        await writer.WriteLineAsync($"[{DateTime.Now}] Request: {await request.Content.ReadAsStringAsync()}");
//                    }
//                }
//            }
//        }

//        private async Task LogResponse(HttpResponseMessage response)
//        {
//            // Check if the user is authenticated
//            if (response.RequestMessage.GetRequestContext().Principal.Identity.IsAuthenticated)
//            {
//                // Get the subscriber ID claim
//                var subscriberIdClaim = (response.RequestMessage.GetRequestContext().Principal as ClaimsPrincipal)?.FindFirst("subscriberId");

//                if (subscriberIdClaim != null)
//                {
//                    string subscriberId = subscriberIdClaim.Value;

//                    // Create a file with the subscriber ID and current date as the name
//                    string fileName = $"{subscriberId}_{DateTime.Now:dd.MM.yyyy}.txt";
//                    string filePath = Path.Combine(logFolderPath, fileName);

//                    // Log the response to the file
//                    using (StreamWriter writer = File.AppendText(filePath))
//                    {
//                        await writer.WriteLineAsync($"[{DateTime.Now}] Response: {await response.Content.ReadAsStringAsync()}");
//                    }
//                }
//            }
//        }
//    }
//}




