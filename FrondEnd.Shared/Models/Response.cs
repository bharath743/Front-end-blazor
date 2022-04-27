using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrondEnd.Shared.Models
{
    /// <summary>
    /// Base response obj
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public Response(string status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; } = default!;


    }
}
