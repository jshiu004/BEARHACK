
public class Food {
    private string name;
    private int calories;

    public Food(string n, int cal) {
        name = n;
        calories = cal;
    }

    public string getName() { return name; }
    public int getCalories() { return calories; }

    public string printCals() {
        return name + ": " + calories + " calories.";
    }

}