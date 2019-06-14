using System.Runtime.Serialization;

namespace FP.Models
{
    [DataContract]
    public class Message<T>
    {
        #region  Properties

        [DataMember(Name = "IsSuccess")] public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")] public string ReturnMessage { get; set; }

        [DataMember(Name = "Data")] public T Data { get; set; }

        #endregion
    }
}