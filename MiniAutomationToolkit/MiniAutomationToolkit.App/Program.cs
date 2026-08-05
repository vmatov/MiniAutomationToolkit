using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Services;

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