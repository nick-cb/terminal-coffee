String[][] productList = [
    ["artisan", "Working the backend and frontend of the palette, this new artisinal infusion is a collaboration with Laravel from Colombia and Papua New Guinea and is full stack in flavour and texture"],
    ["[object object]", "The interpolation of Caturra and Castillo varietals from Las Cochitas creates this refreshing citrusy and complex coffee"],
    ["segfault", "A savory yet sweet blend created from a natural fault in the coffee cherry that causes it to develop one bean instead of two"],
    ["dark mode", "A dark roast from the Cerrado region of Brazil, an expansive lush and tropical savanna that creates a dark chocolate blend with hints of almond"],
    ["404", "A flavorful decaf coffee processed in the mountain waters of Brazil to create a dark chocolatey blend."]
];

int[] cart = [0, 0, 0, 0, 0];

void RenderProductList(int cursorPos, int checkedIdx)
{
    for (int i = 0; i < productList.Length; i++)
    {
        if (cursorPos == i)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"---> {i}: {productList[i][0]}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(productList[i][1]);
            Console.ResetColor();
            Console.WriteLine($"- {cart[i]} +");
            Console.ResetColor();
            continue;
        }
        Console.WriteLine($"{i}: {productList[i][0]}");
        Console.ResetColor();
    }
}

var selected = 0;
var checkedIdx = -1;
Console.Clear();
RenderProductList(selected, checkedIdx);

do
{
    var key = Console.ReadKey();
    if (key.Key is ConsoleKey.Escape or ConsoleKey.Q)
    {
        break;
    }
    
    Console.WriteLine();
    switch (key.Key)
    {
        case ConsoleKey.J:
            selected = Math.Min(4, (selected + 1) % productList.Length);
            Console.Clear();
            RenderProductList(selected, checkedIdx);
            break;
        case ConsoleKey.K:
            selected = (selected - 1) % productList.Length;
            if (selected < 0)
            {
                selected = productList.Length - 1;
            }
            Console.Clear();
            RenderProductList(selected, checkedIdx);
            break;
        case ConsoleKey.Spacebar:
            checkedIdx = selected;
            Console.Clear();
            RenderProductList(selected, checkedIdx);
            break;
        case ConsoleKey.L:
            cart[selected] = Math.Min(Math.Max(0, cart[selected] + 1), 100);
            Console.Clear();
            RenderProductList(selected, checkedIdx);
            break;
        case ConsoleKey.H:
            cart[selected] = Math.Min(Math.Max(0, cart[selected] - 1), 100);
            Console.Clear();
            RenderProductList(selected, checkedIdx);
            break;
    }
} while (true);

/* What high-level components do I need?
 * - a terminal rendering framework
 *      - how to render a view (blank canvas)
 * - application logic
 */