using System;
using System.Linq;
using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Services;
using APBD_Cw1_s30115.Services.Equipment;
using APBD_Cw1_s30115.Services.Rental;
using APBD_Cw1_s30115.Services.User;
using APBD_Cw1_s30115.Enums;
using APBD_Cw1_s30115.Exceptions;

Console.WriteLine("=== UNIVERSITY EQUIPMENT RENTAL SYSTEM ===\n");

IEquipmentService equipmentService = new EquipmentService();
IRentalService rentalService = new RentalService();
IUserService userService = new UserService();

var student = new Student("Jan", "Kowalski");
var employee = new Employee("Adam", "Wisniewski");

userService.AddUser(student);
userService.AddUser(employee);

var laptop = new Laptop("ThinkPad", "T14", "Lenovo", "Windows 11", "1920x1080");
var camera = new Camera("A7 III", "Alpha", "Sony", true, "24.2 MP");
var projector = new Projector("Epson Pro", "X300", "Epson", "4K", 3000);
var brokenProjector = new Projector("Epson Basic", "X100", "Epson", "1080p", 2000);

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(projector);
equipmentService.AddEquipment(brokenProjector);

equipmentService.SetStatusMaintenance(brokenProjector.ID);

try 
{
    Console.WriteLine("[Valid Rental]: Student borrows a laptop.");
    rentalService.CreateRental(student, laptop, DateTime.Now, DateTime.Now.AddDays(3));
    Console.WriteLine("Success.\n");
} 
catch (Exception e) 
{ 
    Console.WriteLine(e.Message + "\n"); 
}

try 
{
    Console.WriteLine("[Invalid Rental]: Attempt to borrow a projector in maintenance.");
    rentalService.CreateRental(student, brokenProjector, DateTime.Now, DateTime.Now.AddDays(1));
} 
catch (Exception e) 
{ 
    Console.WriteLine(e.Message + "\n"); 
}

try 
{
    Console.WriteLine("[Limit Check]: Student attempts to exceed the rental limit.");
    rentalService.CreateRental(student, camera, DateTime.Now, DateTime.Now.AddDays(2)); 
    rentalService.CreateRental(student, projector, DateTime.Now, DateTime.Now.AddDays(2)); 
} 
catch (Exception e) 
{ 
    Console.WriteLine(e.Message + "\n"); 
}

try 
{
    Console.WriteLine("[On-Time Return]: Student returns the camera on time.");
    var studentRentals = rentalService.GetUserReservations(student);
    var cameraRental = studentRentals.FirstOrDefault(r => r.Equipment.ID == camera.ID);
    if (cameraRental != null) 
    {
        rentalService.FinishRental(cameraRental.Id, DateTime.Now);
        Console.WriteLine("Success.\n");
    }
} 
catch (Exception e) 
{ 
    Console.WriteLine(e.Message + "\n"); 
}

try 
{
    Console.WriteLine("[Delayed Return]: Student returns the laptop with a delay.");
    var studentRentals = rentalService.GetUserReservations(student);
    var laptopRental = studentRentals.FirstOrDefault(r => r.Equipment.ID == laptop.ID);
    if (laptopRental != null) 
    {
        rentalService.FinishRental(laptopRental.Id, laptopRental.To.AddDays(5));
    }
} 
catch (Exception e) 
{ 
    Console.WriteLine(e.Message + "\n"); 
}

Console.WriteLine("\n=== FINAL SYSTEM REPORT ===");
var allEquipment = equipmentService.GetAll();
var availableEquipment = equipmentService.GetAvailable();
var overdueRentals = rentalService.GetOverdueRentals(DateTime.Now);

Console.WriteLine($"- Total Users: {userService.GetAll().Count}");
Console.WriteLine($"- Total Equipment: {allEquipment.Count}");
Console.WriteLine($"- Available Equipment: {availableEquipment.Count}");
Console.WriteLine($"- Equipment in Maintenance: {allEquipment.Count(e => e.Status == EquipmentStatus.Maintenance)}");
Console.WriteLine($"- Overdue Rentals: {overdueRentals.Count}");
Console.WriteLine("===========================\n");