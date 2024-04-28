using System.IO;
#include "foodClass.cs";

Food[] readFiles() {
    string caloriesString, name;

    int numFoods = 50;
    Food [] listOfFoods = new Food[numFoods];
    const string path = "foods.txt";
    StreamReader reader = new StreamReader(path);

    for(int i = 0; i < numFoods; i++) {
        name = reader.ReadLine();
        caloriesString = reader.ReadLine();
        if(int.TryParse(caloriesString, out int calories)) {
            listOfFoods[i] = new Food(name, calories);
        }
    }
    return listOfFoods;
}