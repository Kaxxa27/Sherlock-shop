using SherlockShop.WEB.Models;

namespace SherlockShop.WEB.Services.IServices;

public interface IBaseService: IDisposable
{
	ResponseDto responseModel { get; set; }
	Task<T> SendAsync <T>(ApiRequest apiRequest);
}
