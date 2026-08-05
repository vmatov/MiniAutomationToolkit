using System;

public record UserDto
{
	public string Name { get; }
	public string Email { get; }

	public UserDto(string Name, string Email)
	{
		try 
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				throw new ArgumentException("Invalid name: it cannot be null or whitespace", nameof(Name));
			}
			if (string.IsNullOrWhiteSpace(Email))
		{
			throw new ArgumentException("Invalid email: it cannot be null or whitespace", nameof(Email));
		}
		if (!Email.Contains("@"))
		{
			throw new ArgumentException("Invalid email: " + Email, nameof(Email));
		}
		if (Email.Contains(" "))
		{
			throw new ArgumentException("Invalid email: " + Email, nameof(Email));
		}
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}

		this.Name = Name;
		this.Email = Email;
	}
}

