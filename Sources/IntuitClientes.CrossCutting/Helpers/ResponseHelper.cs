using IntuitClientes.CrossCutting.Dtos;

namespace IntuitClientes.CrossCutting.Helpers
{
    public static class ResponseHelper
    {
        public static BaseResponseDto<T> BuildError<T>(string ex)
        {
            BaseResponseDto<T> response = new BaseResponseDto<T>();
            response.IsSuccess = false;
            response.ErrorMessages = new List<string>() { ex.ToString() };
            response.Result = default(T)!;
            response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            return response;
        }

        public static BaseResponseDto<T> BuildError<T>(List<string> list_ex)
        {
            BaseResponseDto<T> response = BuildError<T>("");
            response.ErrorMessages = list_ex;
            return response;
        }

        public static BaseResponseDto<T> BuildError<T>(System.Net.HttpStatusCode code, string error)
        {
            BaseResponseDto<T> response = BuildError<T>(error);
            response.StatusCode = code;
            return response;
        }
        public static BaseResponseDto<T> BuildError<T>(System.Net.HttpStatusCode code)
        {
            return BuildError<T>(code, "");
        }

        public static BaseResponseDto<T> BuildOk<T>(T obj)
        {
            BaseResponseDto<T> response = new BaseResponseDto<T>();
            response.IsSuccess = true;
            response.Result = obj;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return response;
        }
    }
}
