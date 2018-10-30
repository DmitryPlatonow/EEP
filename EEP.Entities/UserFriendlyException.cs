using System;

namespace EEP.Entities
{
    public class UserFriendlyException : Exception
    {
        
        public string Details { get; private set; }

        public int Code { get; set; }

      
        public UserFriendlyException()
        {         
        }       
        public UserFriendlyException(string message)
            : base(message)
        {           
        }
                           
        public UserFriendlyException(int code, string message)
            : this(message)
        {
            Code = code;
        }
     
        public UserFriendlyException(string message, string details)
            : this(message)
        {
            Details = details;
        }
     
        public UserFriendlyException(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }
    }
}
