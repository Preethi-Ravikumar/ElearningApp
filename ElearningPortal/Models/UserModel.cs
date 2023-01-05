using System;
namespace ElearningPortal.Models;

	public class UserModel
	{
    //private UserStoreContext context;
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}