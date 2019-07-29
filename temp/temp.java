public class Temp {

	public static void main(String[] args) {

		String temp = "temporary"; // Just a comment
		int num_temp = 32;
		int gross = num_temp;
		//int gross2 = gross;
		/* Another Comment */
		for (int i = 0; i < num_temp / 2; i++) {
			gross = Math.floor(gross / (i + 1));
			if (gross <= num_temp / 2) {
				countUp(gross);
			}
		}

	}

	public static int countUp(int num) {
		int returnBack = 0;
		for (int i = num; i > 0; i-- {
			returnBack *= num;
		}
		return returnBack;
	}
}