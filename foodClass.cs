


class Food {
    private string name;
    private int calories;

    public Food(string n, int cal) {
        name = n;
        calories = cal;
    }

    public string printCals() {
        return name + ": " + calories + " calories.";
    }

}