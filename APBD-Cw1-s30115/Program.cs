using APBD_Cw1_s30115.Models;
using APBD_Cw1_s30115.Services;
using APBD_Cw1_s30115.Services.Rental;
using APBD_Cw1_s30115.Exceptions;

Console.WriteLine("=== START SYSTEMU WYPOŻYCZALNI ===\n");

// 1. Inicjalizacja serwisów
var equipmentService = new EquipmentService();
var rentalService = new RentalService();

// 2. Tworzenie testowych użytkowników
var student = new Student("Kuba", "Staniszewski");
var wykladowca = new Employee("Jan", "Kowalski");

// 3. Tworzenie testowego sprzętu
var camera = new Camera("A7 III", "Alpha", "Sony", true, "24.2 MP");
var laptop = new Laptop("ThinkPad", "T14", "Lenovo", "Windows 11", "1920x1080");
var projector = new Projector("Epson Pro", "X300", "Epson", "4K", 3000);

// 4. Dodajemy sprzęt do bazy
equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(projector);

Console.WriteLine("--- DOSTĘPNY SPRZĘT (Przed wypożyczeniem) ---");
foreach (var eq in equipmentService.GetAvailable())
{
    Console.WriteLine($"ID: {eq.ID} | {eq.Manufacturer} {eq.Name} | Status: {eq.Status}");
}

// 5. Robimy pierwsze wypożyczenie!
Console.WriteLine("\n--- WYPOŻYCZANIE ---");
Console.WriteLine($"Student {student.firstName} wypożycza aparat {camera.Name}...");
rentalService.CreateRental(student, camera, DateTime.Now, DateTime.Now.AddDays(3));

Console.WriteLine("\n--- DOSTĘPNY SPRZĘT (Po wypożyczeniu) ---");
foreach (var eq in equipmentService.GetAvailable())
{
    // Zauważ, że aparat Sony zniknie z tej listy, bo ma status Rented!
    Console.WriteLine($"ID: {eq.ID} | {eq.Manufacturer} {eq.Name} | Status: {eq.Status}");
}

// 6. Testujemy Twój piękny wyjątek! (Próba wypożyczenia zajętego sprzętu)
Console.WriteLine("\n--- TESTOWANIE WYJĄTKÓW (Zabezpieczeń) ---");
try
{
    Console.WriteLine($"Wykładowca {wykladowca.firstName} próbuje wypożyczyć zajęty aparat {camera.Name}...");
    // To powinno wywalić błąd, bo aparat jest już u studenta!
    rentalService.CreateRental(wykladowca, camera, DateTime.Now, DateTime.Now.AddDays(1));
}
catch (EquipmentNotAvailableException ex)
{
    // Złapaliśmy Twój wyjątek! Program się nie crashuje, tylko ładnie wypisuje Twój błąd na czerwono
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ZŁAPANO BŁĄD: {ex.Message}");
    Console.ResetColor();
}

// 7. Oddajemy sprzęt
Console.WriteLine("\n--- ZWRACANIE SPRZĘTU ---");
var kubaRentals = rentalService.GetUserReservations(student);
var wypozyczenieDoZwrotu = kubaRentals[0]; // Bierzemy pierwsze wypożyczenie z brzegu

Console.WriteLine($"Student {student.firstName} oddaje sprzęt (Wypożyczenie ID: {wypozyczenieDoZwrotu.Id})...");
rentalService.EndRental(wypozyczenieDoZwrotu.Id);

Console.WriteLine("\n--- DOSTĘPNY SPRZĘT (Po zwrocie) ---");
foreach (var eq in equipmentService.GetAvailable())
{
    // Aparat Sony znowu wraca na listę!
    Console.WriteLine($"ID: {eq.ID} | {eq.Manufacturer} {eq.Name} | Status: {eq.Status}");
}

Console.WriteLine("\n=== KONIEC ===");