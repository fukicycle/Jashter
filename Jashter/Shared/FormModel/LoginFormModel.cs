using System;
using System.ComponentModel.DataAnnotations;
namespace Jashter.Shared.FormModel
{
	public class LoginFormModel
	{
		[Required]
		public string Username { get; set; } = null!;

		[Required]
		public string Password { get; set; } = null!;
	}
}

