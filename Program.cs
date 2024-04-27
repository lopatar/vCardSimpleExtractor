// See https://aka.ms/new-console-template for more information

Console.Write("Enter file name: ");

var filePath = Console.ReadLine();

if (!File.Exists(filePath))
{
    Console.WriteLine("File does not exist");
    return;
}
    
var fileData = File.ReadAllText(filePath);
var vCards = fileData.Split("BEGIN:VCARD");

foreach (var splitBegin in vCards)
{
    var endVcards = splitBegin.Split("END:VCARD");

    foreach (var splitEnd in endVcards)
    {
        var vCardLines = splitEnd.Split(Environment.NewLine);

        foreach (var vCardLine in vCardLines)
        {
            if (vCardLine.StartsWith("FN:"))
            {
                Console.WriteLine("Contact name: {0}", vCardLine.Replace("FN:", ""));
                continue;
            }

            if (vCardLine.StartsWith("TEL;"))
            {
                Console.WriteLine("Contact phone number: {0}", vCardLine[(vCardLine.IndexOf(':') + 1)..]);
                Console.WriteLine("-----------------------------------");
                break;
            }
        }
    }
}