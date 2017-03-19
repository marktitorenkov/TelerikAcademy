public class Chef
{
	public void Cook()
	{
		var potato = GetPotato();
		var carrot = GetCarrot();
		var bowl = GetBowl();

		this.Peel(potato);
		this.Peel(carrot);
		
		this.Cut(potato);
		this.Cut(carrot);
		
		bowl.Add(potato);
		bowl.Add(carrot);
	}

	private Potato GetPotato()
	{
		//...
	}
	private Carrot GetCarrot()
	{
		//...
	}
	private Bowl GetBowl()
	{   
		//... 
	}

	private void Peel(Vegetable vegetable)
	{
		//...
	}
	private void Cut(Vegetable vegetable)
	{
		//...
	}
}
