using IntuitClientes.CrossCutting.Base;

namespace IntuitClientes.CrossCutting.Dtos
{
    public class BaseResponseDto<T>: BaseRestResponse
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public T? Result { get; set; }

    }
}
