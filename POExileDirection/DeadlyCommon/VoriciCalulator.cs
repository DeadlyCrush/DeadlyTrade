using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POExileDirection
{
	class VoriciCalulator
	{
	
		int[][] voriciRecipe = new int[20][]{
			new int[] { 0, 0, 0, 1 },
			new int[] { 0, 0, 0, 1 },
			new int[] { 1, 0, 0, 4 },
			new int[] { 0, 1, 0, 4 },
			new int[] { 0, 0, 1, 4 },
			new int[] { 2, 0, 0, 25 },
			new int[] { 0, 2, 0, 25 },
			new int[] { 0, 0, 2, 25 },
			new int[] { 0, 1, 1, 15 },
			new int[] { 1, 0, 1, 15 },
			new int[] { 1, 1, 0, 15 },
			new int[] { 3, 0, 0, 120 },
			new int[] { 0, 3, 0, 120 },
			new int[] { 0, 0, 3, 120 },
			new int[] { 2, 1, 0, 100 },
			new int[] { 2, 0, 1, 100 },
			new int[] { 0, 2, 1, 100 },
			new int[] { 1, 2, 0, 100 },
			new int[] { 1, 0, 2, 100 },
			new int[] { 0, 1, 2, 100 }
		};

		int[][] reqANDdesired = new int[2][]; // [0] : Requirement, [1] : Desired

		double[] requirementToChance = { 0.0, 0.0, 0.0 };

		public struct probs
		{
			public string cratfType;
			public string averageCost;
			public string successChance;
			public string averageAttempts;
			public string costPerTry;
		}

		// private static probs[] probsST = new probs[20];

		public probs[] MainCalc(int totalSockets, int STR, int DEX, int _INT, int RED, int GREEN, int BLUE)
		{
			probs[] probsST = new probs[20];

			bool error = false;
			int socks = totalSockets;
			int str = STR;
			int dex = DEX;
			int _int = _INT;
			int red = RED;
			int green = GREEN;
			int blue = BLUE;

			if (socks <= 0 || socks > 6)
			{
				// recipeName,avgCost,chance,avgTries,recipeCost,stdDev,favg
				error = true;
				probsST[0].cratfType = "Invalid number of sockets.";
				return probsST;
			}
			if (str < 0 || dex < 0 || _int < 0) {
				error = true;
				probsST[0].cratfType = "Invalid item stat requirements.";
				return probsST;
			}
			if (str == 0 && dex == 0 && _int == 0) {
				error = true;
				probsST[0].cratfType = "Please fill in stat requirements.";
				return probsST;
			}
			if (red < 0 || green < 0 || blue < 0 || red + blue + green == 0 || red > 6 || green > 6 || blue > 6 || red + blue + green > socks)
			{
				error = true;
				probsST[0].cratfType = "Invalid desired socket colors.";
				return probsST;
			}

			// Do Calc.
			if (!error)
			{
				reqANDdesired[0] = new int[3] { str, dex, _int };
				reqANDdesired[1] = new int[3] { red, green, blue };
				probsST = getProbabilities(reqANDdesired[0], reqANDdesired[1], socks);
			}

			return probsST;
		}

		private probs[] getProbabilities(int[] requirements, int[] desired, int totalSockets)
		{
			probs[] probsST = new probs[20];

			double[] colorChances = getColorChances(requirements);
			
			// Not Necessory simulateLotsOfChromatics(colorChances[0], totalSockets);
			int nIndex = 0;
			while (nIndex < voriciRecipe.Length)
			{
				if (voriciRecipe[nIndex][0] <= desired[0] && voriciRecipe[nIndex][1] <= desired[1] && voriciRecipe[nIndex][2] <= desired[2])
				{
					int[][] unvoricifiedDesires = new int[1][];
					unvoricifiedDesires[0] = new int[3] {
															desired[0] - voriciRecipe[nIndex][0],
															desired[1] - voriciRecipe[nIndex][1],
															desired[2] - voriciRecipe[nIndex][2]
														};
					var howManySocketsDoWeNotCareAbout = totalSockets - (desired[0] + desired[1] + desired[2]);
					var chance = multinomial(colorChances, unvoricifiedDesires[0], howManySocketsDoWeNotCareAbout);
					if (nIndex == 1)
					{
						double chanceForChromaticCollision = calcChromaticBonus(colorChances, unvoricifiedDesires[0], totalSockets);
						chance = chance / (1 - chanceForChromaticCollision);
					}

					string strDescription = String.Empty;

                    #region [[[[[ Craft Description ]]]]]
                    switch (nIndex)
					{
						/*
						new int[] { 0, 0, 0, 1 },
						new int[] { 0, 0, 0, 1 },
						new int[] { 1, 0, 0, 4 },
						new int[] { 0, 1, 0, 4 },
						new int[] { 0, 0, 1, 4 },
						new int[] { 2, 0, 0, 25 },
						new int[] { 0, 2, 0, 25 },
						new int[] { 0, 0, 2, 25 },
						new int[] { 0, 1, 1, 15 },
						new int[] { 1, 0, 1, 15 },
						new int[] { 1, 1, 0, 15 },
						new int[] { 3, 0, 0, 120 },
						new int[] { 0, 3, 0, 120 },
						new int[] { 0, 0, 3, 120 },
						new int[] { 2, 1, 0, 100 },
						new int[] { 2, 0, 1, 100 },
						new int[] { 0, 2, 1, 100 },
						new int[] { 1, 2, 0, 100 },
						new int[] { 1, 0, 2, 100 },
						new int[] { 0, 1, 2, 100 }
						 */
						case 0:
							strDescription = "Drop Rate";
							break;
						case 1:
							strDescription = "Chromatic Orb";
							break;
						case 2:
							strDescription = "Craft 1R";
							break;
						case 3:
							strDescription = "Craft 1G";
							break;
						case 4:
							strDescription = "Craft 1B";
							break;
						case 5:
							strDescription = "Craft 2R";
							break;
						case 6:
							strDescription = "Craft 2G";
							break;
						case 7:
							strDescription = "Craft 2B";
							break;
						case 8:
							strDescription = "Craft 1G 1B";
							break;
						case 9:
							strDescription = "Craft 1R 1B";
							break;
						case 10:
							strDescription = "Craft 1R 1G";
							break;
						case 11:
							strDescription = "Craft 3R";
							break;
						case 12:
							strDescription = "Craft 3G";
							break;
						case 13:
							strDescription = "Craft 3B";
							break;
						case 14:
							strDescription = "Craft 2R 1G";
							break;
						case 15:
							strDescription = "Craft 2R 1B";
							break;
						case 16:
							strDescription = "Craft 2G 1B";
							break;
						case 17:
							strDescription = "Craft 1R 2G";
							break;
						case 18:
							strDescription = "Craft 1R 2B";
							break;
						case 19:
							strDescription = "Craft 1G 2B";
							break;
						default:							
							break;
					}
					#endregion

					probsST[nIndex].cratfType = strDescription;
					probsST[nIndex].averageCost = Convert.ToDouble(voriciRecipe[nIndex][3] / chance).ToString("N1");
					probsST[nIndex].successChance = Convert.ToDouble(chance * 100).ToString("N5") + "%";
					probsST[nIndex].averageAttempts = Convert.ToDouble(1 / chance).ToString("N1");					
					probsST[nIndex].costPerTry = nIndex == 0 ? "-" : voriciRecipe[nIndex][3].ToString() == null
												? "null" : "" + voriciRecipe[nIndex][3].ToString();
					nIndex = nIndex + 1;
				}
				else
					nIndex = nIndex + 1;
			}

			return probsST;
		}
				
		private double[] getColorChances(int[] requirements)
		{
			double _maxOnColorChance = 0.9;

			var X = 5;
			var C = 5;
			var totalRequirements = requirements[0] + requirements[1] + requirements[2];
			var numberOfRequirements = (requirements[0] > 0 ? 1 : 0) + (requirements[1] > 0 ? 1 : 0) + (requirements[2] > 0 ? 1 : 0);

			bool bStr = false;
			bool bDex = false;
			bool bInt = false;

			if (requirements[0] > 0)
				bStr = true;
			if (requirements[1] > 0)
				bDex = true;
			if (requirements[2] > 0)
				bInt = true;

			double _str, _dex, _int;
			if (requirements[0] == 0)
				_str = 0.5;
			else
				_str = (double)requirements[0];

			if (requirements[1] == 0)
				_dex = 0.5;
			else
				_dex = (double)requirements[1];

			if (requirements[2] == 0)
				_int = 0.5;
			else
				_int = (double)requirements[2];

			double sss;
			double ddd;
			double iii;
			switch (numberOfRequirements)
			{
				case 1:
					if (bStr || bDex || bInt)
					{
						sss = _maxOnColorChance * (X + C + _str) / (totalRequirements + 3 * X + C);
						ddd = _maxOnColorChance * (X + C + _dex) / (totalRequirements + 3 * X + C);
						iii = _maxOnColorChance * (X + C + _int) / (totalRequirements + 3 * X + C);

						requirementToChance = new double[] { sss, ddd, iii };
					}
					else
					{
						requirementToChance = new double[] { 
							(1 - _maxOnColorChance) / 2 + _maxOnColorChance * (X / (totalRequirements + 3 * X + C)),
							(1 - _maxOnColorChance) / 2 + _maxOnColorChance * (X / (totalRequirements + 3 * X + C)),
							(1 - _maxOnColorChance) / 2 + _maxOnColorChance * (X / (totalRequirements + 3 * X + C))
						};
					}
					break;
				case 2:
					if ((bStr && bDex) || (bStr && bInt) || (bDex && bInt))
					{
						sss = _maxOnColorChance * _str / totalRequirements;
						ddd = _maxOnColorChance * _dex / totalRequirements;
						iii = _maxOnColorChance * _int / totalRequirements;

						requirementToChance = new double[] { sss, ddd, iii };
					}
					else
					{
						requirementToChance = new double[] { (1 - _maxOnColorChance)*10, (1 - _maxOnColorChance)*10, (1 - _maxOnColorChance)*10 };
					}
					break;
				case 3:
					requirementToChance = new double[] {
						_str / totalRequirements,
						_dex / totalRequirements,
						_int / totalRequirements 
					};
					break;
			}

			return requirementToChance;
		}

		private double multinomial(double[] colorChances, int[] desired, int free, int pos = 1)
		{
			int[][] Colored = new int[1][];

			double lnResult;
			if (free > 0)
			{
				double aaa = pos <= 1 ? multinomial(colorChances, Colored[0] = new int[3] { desired[0] + 1, desired[1], desired[2] }, free - 1, 1) : 0;
				double bbb = pos <= 2 ? multinomial(colorChances, Colored[0] = new int[3] { desired[0], desired[1] + 1, desired[2] }, free - 1, 2) : 0;
				double ccc = multinomial(colorChances, Colored[0] = new int[3] { desired[0], desired[1], desired[2] + 1 }, free - 1, 3);
				lnResult = aaa + bbb + ccc;
				return lnResult;
			}
			else
			{
				// CHK.
				double aaa = factorialFunc(desired[0]);
				double bbb = factorialFunc(desired[1]);
				double ccc = factorialFunc(desired[2]);

				double abc = aaa * bbb * ccc;

				double ddd = Math.Pow(colorChances[0], desired[0]);
				double eee = Math.Pow(colorChances[1], desired[1]);
				double fff = Math.Pow(colorChances[2], desired[2]);
				lnResult = factorialFunc(desired[0] + desired[1] + desired[2])
							/
							abc
							* ddd
							* eee
							* fff;
				return lnResult;
			}
		}

		private double calcChromaticBonus(double[] colorChances, int[] desired, int free, int[] rolled = null, int pos = 1)
		{
			double lnResult;

			int[][] Colored = new int[1][];

			if (rolled == null) rolled = Colored[0] = new int[3] { 0, 0, 0 };
			if (rolled[0] >= desired[0] && rolled[1] >= desired[1] && rolled[2] >= desired[2])
				return 0;
			else if (free > 0)
			{
				lnResult = (pos <= 1 ? calcChromaticBonus(colorChances, desired, free - 1, Colored[0] = new int[3] { rolled[0] + 1, rolled[1], rolled[2] }, 1) : 0)
					+ (pos <= 2 ? calcChromaticBonus(colorChances, desired, free - 1, Colored[0] = new int[3] { rolled[0], rolled[1] + 1, rolled[2] }, 2) : 0)
					+ calcChromaticBonus(colorChances, desired, free - 1, Colored[0] = new int[3] { rolled[0], rolled[1], rolled[2] + 1 }, 3);
			}
			else
			{
				lnResult = factorialFunc(rolled[0] + rolled[1] + rolled[2])
					/
					(factorialFunc(rolled[0]) * factorialFunc(rolled[1]) * factorialFunc(rolled[2])
					* Math.Pow(colorChances[0], rolled[0] * 2)
					* Math.Pow(colorChances[1], rolled[1] * 2)
					* Math.Pow(colorChances[2], rolled[2] * 2));
			}

			return lnResult;
		}
		private double factorialFunc(double x)
		{
			double sign = 1;
			double r = 1;
			if (x < 0)
			{
				sign = -1;
				x *= -1;
			}
			while (x > 1)
			{
				r *= x;
				--x;
			}
			return r * sign;
		}

		public double factorialCalcLoop(double i)
		{
			if (i <= 1)
				return 1;
			return i * factorialCalcLoop(i - 1);
		}
	}
}
