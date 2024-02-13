using System.ComponentModel.DataAnnotations;

namespace AmcomanApi.ViewModel.Authentication
{
	public class LoginVm
	{
		[Required(ErrorMessage = "Username is required")]
		public string UserName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
    }
}
