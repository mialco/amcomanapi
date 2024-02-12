using System.ComponentModel.DataAnnotations;

namespace AmcomanApi.ViewModel.Authentication
{
	public class RegisterUserVm
	{
		[Required(ErrorMessage="Username is required")]
		public string UserName { get; set; }
		[Required(ErrorMessage="Email is required")]
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required(ErrorMessage="Password is required")]
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
