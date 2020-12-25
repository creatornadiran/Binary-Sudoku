using System;
using System.IO;

namespace PBL_SUDOKU
{
	class Program
	{
		static void Main(string[] args)
		{
			int a;
			int b;
			int[,] to_delete = new int[2, 3];
			int point = 0;
			int cursorx = 2, cursory = 2;
			Random rand = new Random();
			int[,] piece = new int[3, 3];
			int[,] board = new int[9, 9];
			int row, column;
			int score = 0;
			int pieceno = 1;
			int iter = 0;
			int random;
			int width = 0, lenght = 0;
			
			ConsoleKeyInfo key;

			Console.WriteLine("  1 2 3 4 5 6 7 8 9 ");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("1|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("2|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("3|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("4|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("5|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("6|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("7|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("8|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("9|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
			for (int y = 0; y < 9; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					board[y, x] = -1;
				}
			}
			for (int y = 0; y < 9; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					Console.SetCursorPosition(y * 2 + 2, x * 2 + 2);
					if (board[y, x] == -1)
					{
						Console.Write(".");
					}
				}
			}
			while (true)
			{
				//parça değiştirme
				if (pieceno > iter)
				{
					for (int r = 0; r < 3; r++)
					{
						for (int c = 0; c < 3; c++)
						{
							piece[r, c] = -1;
						}
					}
					random = rand.Next(0, 10);
					width = 0; lenght = 0;
					switch (random)
					{
						case 0: piece[0, 0] = rand.Next(0, 2); break;
						case 1:
							piece[0, 0] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							lenght = 2;
							break;
						case 2:
							piece[0, 0] = rand.Next(0, 2);
							piece[0, 1] = rand.Next(0, 2);
							width = 2;
							break;
						case 3:
							piece[0, 0] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							piece[2, 0] = rand.Next(0, 2);
							lenght = 4;
							break;
						case 4:
							piece[0, 0] = rand.Next(0, 2);
							piece[0, 1] = rand.Next(0, 2);
							piece[0, 2] = rand.Next(0, 2);
							lenght = 4;
							break;
						case 5:
							piece[0, 0] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							piece[0, 1] = rand.Next(0, 2);
							width = 2;
							lenght = 2;
							break;
						case 6:
							piece[0, 0] = rand.Next(0, 2);
							piece[0, 1] = rand.Next(0, 2);
							piece[1, 1] = rand.Next(0, 2);
							width = 2;
							lenght = 2;
							break;
						case 7:
							piece[0, 0] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							piece[1, 1] = rand.Next(0, 2);
							width = 2;
							lenght = 2;
							break;
						case 8:
							piece[0, 1] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							piece[1, 1] = rand.Next(0, 2);
							width = 2;
							lenght = 2;
							break;
						case 9:
							piece[0, 0] = rand.Next(0, 2);
							piece[0, 1] = rand.Next(0, 2);
							piece[1, 0] = rand.Next(0, 2);
							piece[1, 1] = rand.Next(0, 2);
							width = 2;
							lenght = 2;
							break;
					}
					iter++;
				}
				//parçayı cursora takma
				for (int r = 0; r < 3; r++)
				{
					for (int c = 0; c < 3; c++)
					{
						if (!(piece[r, c] == -1))
						{
							Console.SetCursorPosition(cursorx + c * 2, cursory + r * 2);
							if (cursorx + c * 2 < 20 && cursory + r * 2 < 20)
							{
								if (board[(cursory / 2) + r - 1, (cursorx / 2) + c - 1] == -1)
								{
									Console.ForegroundColor = ConsoleColor.Yellow;
									Console.Write(piece[r, c]);
								}
								else
								{
									Console.ForegroundColor = ConsoleColor.Red;
									Console.Write("X");
								}
							}
						}
					}
				}
				Console.ForegroundColor = ConsoleColor.Green;
				Console.SetCursorPosition(50, 0);
				Console.WriteLine("Score");
				Console.SetCursorPosition(50, 1);
				Console.Write(score);
				Console.SetCursorPosition(40, 0);
				Console.Write("Piece No");
				Console.SetCursorPosition(40, 1);
				Console.Write(pieceno);
				Console.SetCursorPosition(30, 5);
				Console.Write("Calculations: ");
				Console.SetCursorPosition(30, 0);
				Console.Write("Piece ");

				for (int r = 0; r < 3; r++)
				{
					Console.SetCursorPosition(30, r + 1);
					for (int c = 0; c < 3; c++)
					{
						if (!(piece[r, c] == -1))
						{
							Console.Write(piece[r, c]);
						}
						else
						{
							Console.Write(' ');
						}

					}

				}
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(cursorx, cursory);
				key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.UpArrow && cursory > 2) cursory -= 2;
				else if (key.Key == ConsoleKey.DownArrow && cursory+lenght < 18) cursory += 2;
				else if (key.Key == ConsoleKey.LeftArrow && cursorx > 2) cursorx -= 2;
				else if (key.Key == ConsoleKey.RightArrow && cursorx+width < 18) cursorx += 2;
				if (key.Key == ConsoleKey.Enter)
				{
					row = (cursory - 2) / 2;
					column = (cursorx - 2) / 2;
					int control = 0;
					//control part
					for (int r = 0; r < 3; r++)
					{
						for (int c = 0; c < 3; c++)
						{
							if (!(piece[r, c] == -1))
							{
								if (((row + r >= 9) || (column + c >= 9)) || !(board[row + r, column + c] == -1))
								{
									control++;

								}
							}
						}
					}
					//adding piece
					if (control == 0)
					{
						for (int r = 0; r < 3; r++)
						{
							for (int c = 0; c < 3; c++)
							{
								if (!(piece[r, c] == -1))
								{
									board[row + r, column + c] = piece[r, c];
								}
							}
						}
						pieceno++;
					}
				}
				//Puan hesaplama
				int instant_score = 0;
				int score_tobe_added = 0;
				int completed_parts = 0;
				for (int y = 0; y < 2; y++)
				{
					for (int x = 0; x < 3; x++)
					{
						to_delete[y, x] = -1;
					}
				}
				//yatay hesaplama
				a = 0;
				for (int r = 0; r < 9; r++)
				{
					point = 0;
					for (int c = 0; c < 9; c++)
					{
						if (!(board[r, c] == -1))
						{
							point++;
						}
					}
					if (point == 9)
					{
						Console.SetCursorPosition(30, 6 + completed_parts);
						completed_parts++;
						Console.Write("(");
						b = 9;
						for (int c = 0; c < 9; c++)
						{
							Console.Write(board[r, c]);
							instant_score += board[r, c] * Convert.ToInt32(Math.Pow(2, --b));
						}
						score_tobe_added += instant_score;
						Console.Write($")2 = ({instant_score})10");
						to_delete[0, a] = r;
						a++;
					}
					instant_score = 0;
				}
				//dikey hesaplama
				a = 0;
				for (int c = 0; c < 9; c++)
				{
					point = 0;
					for (int r = 0; r < 9; r++)
					{
						if (!(board[r, c] == -1))
						{
							point++;
						}
					}
					if (point == 9)
					{
						Console.SetCursorPosition(30, 6 + completed_parts);
						completed_parts++;
						Console.Write("(");
						b = 9;
						for (int r = 0; r < 9; r++)
						{
							Console.Write(board[r, c]);
							instant_score += board[r, c] * Convert.ToInt32(Math.Pow(2, --b));
						}
						score_tobe_added += instant_score;
						Console.Write($")2 = ({instant_score})10");
						to_delete[1, a] = c;
						a++;
					}
					instant_score = 0;
				}
				//hücresel hesaplama
				for (int r2 = 0; r2 < 7; r2 += 3)
				{
					for (int c2 = 0; c2 < 7; c2 += 3)
					{
						point = 0;
						for (int c = 0 + c2; c < 3 + c2; c++)
						{
							for (int r = 0 + r2; r < 3 + r2; r++)
							{
								if (!(board[r, c] == -1))
								{
									point++;
								}
							}
						}
						if (point == 9)
						{
							Console.SetCursorPosition(30, 6 + completed_parts);
							completed_parts++;
							Console.Write("(");
							b = 9;
							for (int r = 0 + r2; r < 3 + r2; r++)
							{
								for (int c = 0 + c2; c < 3 + c2; c++)
								{
									Console.Write(board[r, c]);
									instant_score += board[r, c] * Convert.ToInt32(Math.Pow(2, --b));
								}
							}
							score_tobe_added += instant_score;
							Console.Write($")2 = ({instant_score})10");
							//deleting the cell
							for (int c = 0 + c2; c < 3 + c2; c++)
							{
								for (int r = 0 + r2; r < 3 + r2; r++)
								{
									board[r, c] = -1;
								}
							}
						}
					}
				}
				//addinng to score
				score += completed_parts * score_tobe_added;
				if (completed_parts > 0)
				{
					for (int i = 0; i < 9; i++)
					{
						Console.SetCursorPosition(30, 6 + completed_parts + i);
						Console.Write("                                                              ");
					}
					Console.SetCursorPosition(30, 6 + completed_parts);
					Console.Write($"Total: {score_tobe_added}");
					Console.SetCursorPosition(30, 7 + completed_parts);
					Console.Write($"{score_tobe_added} * {completed_parts} = {completed_parts * score_tobe_added} ");
				}
				//deleting completed rows and columns
				for (a = 0; a < 3; a++)
				{
					if (!(to_delete[0, a] == -1))
					{
						for (int c = 0; c < 9; c++)
						{
							board[to_delete[0, a], c] = -1;
						}
					}
					if (!(to_delete[1, a] == -1))
					{
						for (int r = 0; r < 9; r++)
						{
							board[r, to_delete[1, a]] = -1;
						}
					}
				}
				//tabloyu çizme
				for (int r = 0; r < 9; r++)
				{
					for (int c = 0; c < 9; c++)
					{
						Console.SetCursorPosition(c * 2 + 2, r * 2 + 2);
						if (board[r, c] == -1)
						{
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write(".");
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Blue;
							Console.Write(board[r, c]);
						}
					}
				}
				Console.ForegroundColor = ConsoleColor.White;

				//Game Over
				bool isgameover = false;
				for (int y = 0; y < 9; y++)
				{
					for (int x = 0; x < 9; x++)
					{
						int control = 0;
						for (int r = 0; r < 3; r++)
						{
							for (int c = 0; c < 3; c++)
							{
								if (!(piece[r, c] == -1))
								{
									if (((y + r >= 9) || (x + c >= 9)) || !(board[y + r, x + c] == -1))
									{
										control++;
									}
								}
							}
						}
						if (control == 0)
						{
							isgameover = true;
						}
					}
				}
				if (isgameover == false)
				{
					break;
				}
				Console.ForegroundColor = ConsoleColor.White;
			}
			Console.SetCursorPosition(50, 50);

			Console.WriteLine("GAME OVER");
			Console.WriteLine("Please enter your name: ");
			string name = Console.ReadLine();
			StreamWriter f = File.AppendText("scores.txt");
			f.WriteLine($"{name};{point}"); // To make the sort function digit number sensitive
			f.Close();
			//Printing High Score Table
			Console.WriteLine("_".PadRight(46, '_'));
			Console.WriteLine("High Score Table ");
			//To calculate number of score&name - it will be used for many transactions later
			int counter = 0;
			StreamReader f2 = File.OpenText("scores.txt");
			do
			{
				f2.ReadLine();
				counter++;
			} while (!f2.EndOfStream);
			f2.Close();
			string[] array = new string[counter];
			StreamReader f3 = File.OpenText("scores.txt");
			for (int i = 0; i < counter; i++)
			{
				array[i] = f3.ReadLine();
			}
			f3.Close();
			Array.Sort(array);
			StreamWriter f4 = File.CreateText("scores.txt");
			if (counter < 10) //printing if counter <10
			{
				for (int i = 0; i < counter; i++)
				{
					string[] s = array[i].Split(";");
					Console.WriteLine(s[0] + " " + s[1]);
					f4.WriteLine($"{s[0]};{s[1]}");
				}
			}
			else // printing if counter >=10
			{
				for (int i = 0; i < 10; i++)
				{
					string[] s = array[i].Split(";");
					Console.WriteLine(s[0] + " " + s[1]);
					f4.WriteLine($"{s[0]};{s[1]}");
				}
			}
			f4.Close();
		}
	}
}






