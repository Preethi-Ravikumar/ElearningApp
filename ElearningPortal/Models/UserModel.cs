using System;
using System.ComponentModel.DataAnnotations;

namespace ElearningPortal.Models;

public class UserModel
{
    //public enum RoleType
    //{
    //    admin=1,
    //    trainingAdmin=2,
    //    trainer=3,
    //    user=4
    //}
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; } = 3;
    public byte isActive { get; set; } = 1;
    //public List<int> CourseId { get; set; }
    public virtual ICollection<Course>? Courses { get; set; }

    //public UserModel()
    //{
    //    this.Role = RoleType.user;
    //    Console.WriteLine(this.Role + "..................");
    //}
}