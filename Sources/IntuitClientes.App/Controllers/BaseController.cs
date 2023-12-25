using IntuitClientes.CrossCutting.Dtos;
using IntuitClientes.CrossCutting.Helpers;
using IntuitClientes.CrossCutting.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Hasar.MSCoelsa.App.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILog _logger;

        public BaseController(ILog logger)
        {
            _logger = logger;
        }

        protected BaseResponseDto<T> BuildError<T>(Exception ex)
        {
            _logger.Error(ex.Message, ex);
            return ResponseHelper.BuildError<T>(ex.Message);
        }

        protected BaseResponseDto<T> BuildError<T>(List<string> list_ex)
        {
            _logger.Error(list_ex.FirstOrDefault()!);
            return ResponseHelper.BuildError<T>(list_ex);
        }

        protected BaseResponseDto<T> BuildError<T>(System.Net.HttpStatusCode code, string error)
        {
            _logger.Error(error);
            return ResponseHelper.BuildError<T>(code, error);
        }
        protected BaseResponseDto<T> BuildError<T>(System.Net.HttpStatusCode code)
        {
            return BuildError<T>(code, "");
        }

        protected OkObjectResult BuildOk<T>(T obj)
        {
            BaseResponseDto<T> response = ResponseHelper.BuildOk(obj);
            return Ok(response);
        }
    }
}
