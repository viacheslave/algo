using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace LeetCode.Challenge
{
	class Program
	{
		static void Main(string[] args)
		{
      Unsafe.SizeOf<int>();
    }
	}

  public record Person(ParentPerson Parent);

  public record ParentPerson(DateOfBirth DateOfBirth);

  public record DateOfBirth(int Year);
}
