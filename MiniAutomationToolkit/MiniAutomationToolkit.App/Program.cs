using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Services;
using System.Diagnostics;


// Задание 2. «Калькулятор скидок»

var clientOne = new Client(500, ClientType.Vip);

DetailPrint(clientOne);

void DetailPrint(Client client)
{
    var discount = DiscountCalculator.CalculateDiscount(client.Amount, client.Type);
    Console.WriteLine($"Client: {client.Type}, amount: {client.Amount}, discount: {discount}");
}

// Задание 3. «Поиск в хаосе»
var fileNames = new List<string>{"screen_001.log", "error_2026.log", "notes_draft.txt", "screen_002.png", "debug_dump.log", "readme.txt", "screen_screenshot_v2.png", "system_trace.log", "todo_list.txt", "screen_003.png", "access_denied.log", "config_backup.txt", "screen_final.png", "crash_report.log", "instructions.txt", "screen_dashboard.png", "server_response.log", "temp_scratchpad.txt", "screen_preview.png", "network_traffic.log"};
var fileNamesWithoutScreenshots = new List<string>{"error_2026.log", "notes_draft.txt", "debug_dump.log", "readme.txt", "access_denied.log", "config_backup.txt", "crash_report.log", "instructions.txt", "server_response.log", "temp_scratchpad.txt", "network_traffic.log"};
var firstScreenshot = FileSearcher.FindFirstScreenshot(fileNames);
Console.WriteLine($"First screenshot found: {firstScreenshot}");

// Генерируем ошибку
// var secondScreenshot = FileSearcher.FindFirstScreenshot(fileNamesWithoutScreenshots);
// Console.WriteLine($"Second screenshot found: {secondScreenshot}");

// Задание 4. «Неизменяемый пользователь»
var userOne = new UserDto("Alex Smith", "alex@example.com");
var userTwo = new UserDto("Alex Smith", "alex@example.com");
if (userOne == userTwo)
{
    Console.WriteLine("Users are equal");
}
else
{
    Console.WriteLine("Users are not equal");
}

// Ошибка при попытке изменить значение пользователя
// userTwo.Email = "";

// Некорректные пользователи
var badUserOne = new UserDto("", "john@example.com");
var badUserTwo = new UserDto("Jane Doe", "");
var badUserThree = new UserDto("Bob Johnson", "bobexample.com");
var badUserFour = new UserDto("Alice Brown", "al  ice@example.com");

// Задание 5. «Базовая страница»
var loginPage = new LoginPage();
var homePage = new HomePage();
loginPage.Load();
homePage.Load();

var pages = new List<BasePage> { loginPage, homePage };
var uniqueItems = pages.GroupBy(x => x.PageName)
                      .Select(g => g.First())
                      .ToList();
try
{
if (uniqueItems.Count != pages.Count)
{
    throw new InvalidOperationException("Not all page URLs are unique");
}
else
{
    Console.WriteLine("All page URLs are unique");
}
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Задание 6. «Умная конфигурация»
var config = new AppConfig(Path.Combine(".", "MiniAutomationToolkit.App", "data", "appsettings.txt"));

Console.WriteLine(config.GetSetting<string>("baseUrl"));
Console.WriteLine(config.GetSetting<int>("timeout"));
Console.WriteLine(config.GetSetting<bool>("headless"));
Console.WriteLine(config.GetSetting<int>("retryCount"));

// Генерируем ошибку "Key 'missedKey' not found in configuration."
// Console.WriteLine(config.GetSetting<int>("missedKey"));

// Задание 7. «Расширяем возможности строк»
void PrintStringInfo(string input)
{
    if (input == null)
    {
        input = "null";
    }
    Console.WriteLine($"{input} -> {input.HasHttpScheme()}");
}
PrintStringInfo("https://google.com");
PrintStringInfo("http://example.com");
PrintStringInfo("ftp://files.example.com");
PrintStringInfo(null);
PrintStringInfo("HTTPS://SITE.EXAMPLE.COM");

// Задание 8. «Имитация длительной операции»
var simulator = new LongOperationSimulator();
var stopwatch = Stopwatch.StartNew();
var result = await simulator.LongOperationAsync();
stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms. Result: {result}");

// Задание 9. «Логгер ошибок»
var errorLogger = new ErrorLogger();
var sourceFilePath = Path.Combine(".", "MiniAutomationToolkit.App", "data", "input.txt");
var logFilePath = Path.Combine(".", "MiniAutomationToolkit.App", "data", "errors.log");
var content = errorLogger.TryReadFile(sourceFilePath, logFilePath);

// Получаем ошибку при попытке прочитать несуществующий файл
sourceFilePath = Path.Combine(".", "MiniAutomationToolkit.App", "data", "missing.txt");
errorLogger.TryReadFile(sourceFilePath, logFilePath);