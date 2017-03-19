bool valueFound = false;
for (int i = 0; i < 100 && !valueFound; i++) 
{
	var currentValue = array[i];
	Console.WriteLine(currentValue);
	if ((i % 10 == 0) && (currentValue == expectedValue))
	{
		valueFound = true;
	}
}

// More code here

if (valueFound)
{
	Console.WriteLine("Value Found");
}