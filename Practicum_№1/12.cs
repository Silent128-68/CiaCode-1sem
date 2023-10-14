//классы)

//#include <iostream>
//using namespace std;
//
//class Rectangle {
//private:
//    int a, b;
//public:
//    Rectangle(int a = 0, int b = 0) {
//        this->a = a;
//        this->b = b;
//    }
//
//    void printInfo() { // вывод информации о прямоугольнике
//        cout << "Rectangle: " << a << " x " << b << endl;
//    }
//
//    int perimeter() { // расчет периметра
//        return 2 * (a + b);
//    }
//
//    int area() { // расчет площади
//        return a * b;
//    }
//
//    void setSides(int a, int b) { // установка длин сторон
//        this->a = a;
//        this->b = b;
//    }
//
//    bool isSquare() { // проверка на квадрат
//        return a == b;
//    }
//
//    Rectangle operator++(int) { // перегрузка операции ++ (префиксная форма)
//        Rectangle temp(*this);
//        ++a;
//        ++b;
//        return temp;
//    }
//
//    Rectangle operator--() { // перегрузка операции -- (префиксная форма)
//        --a;
//        --b;
//        return *this;
//    }
//
//    Rectangle operator*(int scalar) { // перегрузка операции *
//        a *= scalar;
//        b *= scalar;
//        return *this;
//    }
//};
//
//int main() {
//    Rectangle r(5, 10);
//    r.printInfo(); // вывод информации о прямоугольнике
//
//    r++; // увеличение значений сторон на 1
//    r.printInfo(); // новые значения: 6 x 11
//
//    Rectangle s = --r; // уменьшение значений сторон на 1
//    s.printInfo(); // новые значения: 5 x 10
//
//    Rectangle t = r * 2; // умножение значений сторон на 2
//    t.printInfo(); // новые значения: 10 x 20
//
//    cout << "Perimeter: " << r.perimeter() << endl; // расчет периметра
//    cout << "Area: " << r.area() << endl; // расчет площади
//
//    r.setSides(5, 10); // установка значений сторон для квадрата
//    r.printInfo(); // вывод информации о квадрате
//    cout << "Is square? " << r.isSquare() << endl; // проверка на квадрат
//
//    return 0;
//}








//сортировки 1

//#include <iostream>
//#include <fstream>
//#include <vector>
//#include <algorithm>
//using namespace std;
//
//struct Student {
//    string surname, name, patronymic;
//    int birthYear;
//    vector<int> marks;
//    int sumMarks; // сумма оценок
//};
//
//// функция для чтения данных из файла
//void readDataFromFile(vector<Student>& students, int& groupNumber) {
//    ifstream fin("input.txt");
//    fin >> groupNumber;
//    while (!fin.eof()) {
//        Student s;
//        s.sumMarks = 0; // инициализация нулем
//        fin >> s.surname >> s.name >> s.patronymic >> s.birthYear;
//        for (int i = 0; i < 5; i++) {
//            int mark;
//            fin >> mark;
//            s.marks.push_back(mark);
//            s.sumMarks += mark;
//        }
//        students.push_back(s);
//    }
//    fin.close();
//}
//
//// функция для записи данных в файл
//void writeDataToFile(const vector<Student>& students, const int& groupNumber) {
//    ofstream fout("output.txt");
//    fout << groupNumber << "\n";
//    for (const auto& s : students) {
//        fout << s.surname << " " << s.name << " " << s.patronymic << " " << s.birthYear << " " << s.sumMarks << "\n";
//    }
//    fout.close();
//}
//
//// сортировка выбором
//void selectionSort(vector<Student>& students) {
//    for (int i = 0; i < students.size() - 1; i++) {
//        int minIndex = i;
//        for (int j = i + 1; j < students.size(); j++) {
//            if (students[j].sumMarks < students[minIndex].sumMarks) {
//                minIndex = j;
//            }
//        }
//        swap(students[i], students[minIndex]);
//    }
//}
//
//// сортировка вставками
//void insertionSort(vector<Student>& students) {
//    for (int i = 1; i < students.size(); i++) {
//        Student key = students[i];
//        int j = i - 1;
//        while (j >= 0 && students[j].sumMarks > key.sumMarks) {
//            students[j + 1] = students[j];
//            j--;
//        }
//        students[j + 1] = key;
//    }
//}
//
//// пузырьковая сортировка
//void bubbleSort(vector<Student>& students) {
//    for (int i = 0; i < students.size() - 1; i++) {
//        for (int j = 0; j < students.size() - 1 - i; j++) {
//            if (students[j].sumMarks > students[j + 1].sumMarks) {
//                swap(students[j], students[j + 1]);
//            }
//        }
//    }
//}
//
//int main() {
//    vector<Student> students;
//    int groupNumber;
//    readDataFromFile(students, groupNumber);
//
//    //selectionSort(students);
//    //insertionSort(students);
//    bubbleSort(students);
//
//    writeDataToFile(students, groupNumber);
//    return 0;
//}








//сортировки 2

//#include <iostream>
//using namespace std;
//
//// Функция быстрой сортировки
//void quickSort(int arr[], int left, int right) {
//    int i = left, j = right;
//    int tmp;
//    int pivot = arr[(left + right) / 2];
//
//    /* partition */
//    while (i <= j) {
//        while (arr[i] < pivot)
//            i++;
//        while (arr[j] > pivot)
//            j--;
//        if (i <= j) {
//            tmp = arr[i];
//            arr[i] = arr[j];
//            arr[j] = tmp;
//            i++;
//            j--;
//        }
//    };
//
//    /* recursion */
//    if (left < j)
//        quickSort(arr, left, j);
//    if (i < right)
//        quickSort(arr, i, right);
//}
//
//// Функция преобразования массива в кучу
//void heapify(int arr[], int n, int i) {
//    int largest = i; // Инициализируем наибольший элемент как корень
//    int l = 2 * i + 1; // левый = 2*i + 1
//    int r = 2 * i + 2; // правый = 2*i + 2
//
//    // Если левый дочерний элемент больше корня
//    if (l < n && arr[l] > arr[largest])
//        largest = l;
//
//    // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
//    if (r < n && arr[r] > arr[largest])
//        largest = r;
//
//    // Если самый большой элемент не корень
//    if (largest != i) {
//        swap(arr[i], arr[largest]);
//
//        // Рекурсивно кучафицируем затронутый поддерево
//        heapify(arr, n, largest);
//    }
//}
//
//// Функция сортировки кучей
//void heapSort(int arr[], int n) {
//    // Построение кучи (перегруппируем массив)
//    for (int i = n / 2 - 1; i >= 0; i--)
//        heapify(arr, n, i);
//
//    // Один за другим извлекаем элементы из кучи
//    for (int i = n - 1; i >= 0; i--) {
//        // Перемещаем текущий корень в конец
//        swap(arr[0], arr[i]);
//
//        // вызываем процедуру heapify на уменьшенной куче
//        heapify(arr, i, 0);
//    }
//}
//
//int main() {
//    int n = 3;
//    int matrix[3][3];
//
//    // Ввод матрицы
//    cout << "Enter the elements of matrix: " << endl;
//    for (int i = 0; i < n; i++) {
//        for (int j = 0; j < n; j++) {
//            cin >> matrix[i][j];
//        }
//    }
//
//    // Сортировка каждого столбца матрицы
//    for (int j = 0; j < n; j++) {
//        int col[3];
//        for (int i = 0; i < n; i++) {
//            col[i] = matrix[i][j];
//        }
//        //quickSort(col, 0, n-1); // Используем быструю сортировку
//        heapSort(col, n); // Используем сортировку кучей
//        for (int i = 0; i < n; i++) {
//            matrix[i][j] = col[i];
//        }
//    }
//
//    // Вывод отсортированной матрицы
//    cout << "Sorted matrix:" << endl;
//    for (int i = 0; i < n; i++) {
//        for (int j = 0; j < n; j++) {
//            cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//
//    return 0;
//}
//
//сортировка кучей является более эффективной для данной задачи






//1-св. список

//#include <iostream>
//using namespace std;
//
//class Node {
//public:
//    int data;
//    Node* next;
//    Node(int d) { // конструктор для удобного создания элемента списка
//        data = d;
//        next = NULL;
//    }
//};
//
//class LinkedList {
//private:
//    Node* head;
//public:
//    LinkedList() { // конструктор для создания пустого списка
//        head = NULL;
//    }
//
//    void push(int new_data) { // функция добавления элемента в список
//        Node* new_node = new Node(new_data);
//        new_node->next = head;
//        head = new_node;
//    }
//
//    LinkedList copyList() { //создаем копию списка и возвращаем ее
//        LinkedList copy;
//        Node* temp = head;
//        while (temp != NULL) {
//            copy.push(temp->data);
//            temp = temp->next;
//        }
//        return copy;
//    }
//
//    void splitList(LinkedList& pos_list, LinkedList& neg_list) {
//        Node* temp = head;
//        while (temp != NULL) {
//            if (temp->data >= 0) {
//                pos_list.push(temp->data);
//            }
//            else {
//                neg_list.push(temp->data);
//            }
//            Node* prev = temp; // сохраняем указатель на предыдущий элемент
//            temp = temp->next;
//            delete prev; // удаляем элемент из изначального списка
//        }
//        head = NULL; // обнуляем указатель на голову списка
//    }
//
//    void printList() { // функция вывода списка
//        Node* node = head;
//        while (node != NULL) {
//            cout << node->data << " ";
//            node = node->next;
//        }
//    }
//};
//
//int main() {
//    LinkedList original_list;
//    LinkedList pos_list;
//    LinkedList neg_list;
//
//    original_list.push(1);
//    original_list.push(-7);
//    original_list.push(5);
//    original_list.push(-2);
//    original_list.push(3);
//
//    LinkedList copy = original_list.copyList();
//    copy.splitList(pos_list, neg_list);
//
//    cout << "Original List: ";
//    original_list.printList(); // 3 -2 5 -7 1
//    cout << endl;
//
//    cout << "Positive List: ";
//    pos_list.printList();
//    cout << endl;
//
//    cout << "Negative List: ";
//    neg_list.printList();
//    cout << endl;
//
//    return 0;
//}






//стек

//#include <iostream>
//#include <fstream>
//#include <stack>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    stack<int> positive, negative; // создаем два стека для положительных и отрицательных чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        if (num >= 0) { // если число положительное, добавляем в стек positive
//            positive.push(num);
//        }
//        else { // если число отрицательное, добавляем в стек negative
//            negative.push(num);
//        }
//    }
//    vector<int> result; // создаем вектор для записи результата
//    while (!positive.empty()) { // пока стек положительных чисел не пуст
//        result.push_back(positive.top()); // добавляем последнее число из стека в вектор
//        positive.pop(); // удаляем последнее число из стека
//    }
//    while (!negative.empty()) { // аналогично для стека отрицательных чисел
//        result.push_back(negative.top());
//        negative.pop();
//    }
//    for (int i = 0; i < n; i++) {
//        fout << result[i] << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//очередь

//#include <iostream>
//#include <fstream>
//#include <queue>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    queue<int> positive, negative; // создаем две очереди для положительных и отрицательных чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        if (num >= 0) { // если число положительное, добавляем в очередь positive
//            positive.push(num);
//        }
//        else { // если число отрицательное, добавляем в очередь negative
//            negative.push(num);
//        }
//    }
//    vector<int> result; // создаем вектор для записи результата
//    while (!positive.empty()) { // пока очередь положительных чисел не пуста
//        result.push_back(positive.front()); // добавляем первое число из очереди в вектор
//        positive.pop(); // удаляем первое число из очереди
//    }
//    while (!negative.empty()) { // аналогично для очереди отрицательных чисел
//        result.push_back(negative.front());
//        negative.pop();
//    }
//    for (int i = 0; i < n; i++) {
//        fout << result[i] << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//2-св. список

//#include <iostream>
//#include <fstream>
//#include <list>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    list<int> numbers; // создаем список для чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        numbers.push_back(num); // добавляем число в конец списка
//    }
//    list<int> positive, negative; // создаем два списка для положительных и отрицательных чисел
//    for (auto it = numbers.begin(); it != numbers.end(); ++it) {
//        if (*it >= 0) { // если число положительное, добавляем в список positive
//            positive.push_back(*it);
//        }
//        else { // если число отрицательное, добавляем в список negative
//            negative.push_back(*it);
//        }
//    }
//    positive.splice(positive.end(), negative); // объединяем списки, перемещая все элементы из списка negative в конец списка positive
//    for (auto it = positive.begin(); it != positive.end(); ++it) {
//        fout << *it << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//Vector 1

//#include <iostream>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    vector<int> vec = { 1, 2, 3, 4, 5 };
//    int n = vec.size();
//
//    // заменяем средний элемент на сумму первого и последнего
//    vec[n / 2] = vec[0] + vec[n - 1];
//
//    // выводим измененный вектор
//    for (int i = 0; i < n; i++) {
//        cout << vec[i] << " ";
//    }
//
//    return 0;
//}
//
//Временная сложность для вектора : O(1), так как доступ к элементам вектора происходит за константное время.
//Выбор контейнера : вектор, так как нам нужен быстрый доступ к элементам по индексу.

//List 1

//#include <iostream>
//#include <list>
//
//using namespace std;
//
//int main() {
//    list<int> lst = { 1, 2, 3, 4, 5 };
//
//    // вставляем элемент x перед первым и последним элементами
//    lst.push_front(10);
//    lst.push_back(10);
//
//    // выводим измененный список
//    for (auto it = lst.begin(); it != lst.end(); it++) {
//        cout << *it << " ";
//    }
//
//    return 0;
//}
//
//Временная сложность для списка : O(1), так как вставка элемента в начало и конец списка происходит за константное время.
//Выбор контейнера : список, так как нам нужно быстро вставлять элементы в начало и конец списка.





//stable_sort

//#include <iostream>
//#include <fstream>
//#include <vector>
//#include <algorithm>
//
//using namespace std;
//
//struct Student {
//    string surname;
//    string name;
//    string patronymic;
//    int birth_year;
//    vector<int> marks;
//    int sum_marks = 0; // инициализация переменной sum_marks
//};
//
//bool compare(Student a, Student b) {
//    return a.sum_marks < b.sum_marks;
//}
//
//int main() {
//    ifstream input("input.txt");
//    ofstream output("output.txt");
//    int group_number;
//    input >> group_number;
//    output << "Group number: " << group_number << endl;
//    vector<Student> students;
//    while (!input.eof()) {
//        Student s;
//        input >> s.surname >> s.name >> s.patronymic >> s.birth_year;
//        s.marks.resize(5);
//        for (int i = 0; i < 5; i++) {
//            input >> s.marks[i];
//            s.sum_marks += s.marks[i];
//        }
//        students.push_back(s);
//    }
//    stable_sort(students.begin(), students.end(), compare);
//    for (Student s : students) {
//        output << s.surname << " " << s.name << " " << s.patronymic << " "
//            << s.birth_year << " " << s.sum_marks << endl;
//    }
//    input.close();
//    output.close();
//    return 0;
//}
//В отличие от sort, сортировка stable_sort гарантирует, что порядок элементов с одинаковыми 
//значениями ключа сортировки останется неизменным.Поэтому в данном коде лучше использовать 
//stable_sort, чтобы гарантировать правильный порядок элементов в отсортированном векторе.





//#include <iostream>
//#include <fstream>
//#include <algorithm>
//#include <vector>
//#include <string>
//
//using namespace std;
//
//struct Student {
//    string surname, name, patronymic;     //описываем информацию о студенте, включая его фамилию, имя, отчество, 
//    int birth_year, marks[5], sum_marks;  //год рождения, оценки по пяти предметам и сумму оценок.
//};
//
//bool compare(const Student& a, const Student& b) {
//    return a.sum_marks < b.sum_marks;  //сравниваем студентов по сумме оценок и используется при сортировке.
//}
//
//int main() {                          //считывается информация из файла input.txt, 
//    ifstream input("input.txt");      //создается вектор студентов, для каждого студента вычисляется 
//    ofstream output("output.txt");    //сумма оценок и записывается информация о нем в вектор.
//    vector<Student> students;
//    string group_number;
//    while (input >> group_number) {
//        string surname, name, patronymic;
//        int birth_year, marks[5];
//        int sum_marks = 0;
//        input >> surname >> name >> patronymic >> birth_year;
//        for (int i = 0; i < 5; i++) {
//            input >> marks[i];
//            sum_marks += marks[i];
//        }
//        students.push_back({ surname, name, patronymic, birth_year, {marks[0], marks[1], marks[2], marks[3], marks[4]}, sum_marks });
//    }
//    stable_sort(students.begin(), students.end(), compare);  //Студенты сортируются по возрастанию суммы оценок
//    for (auto& student : students) {
//        output << student.surname << " " << student.name << " " << student.patronymic << " " << student.sum_marks << endl;
//    }
//    return 0;
//}

//алгоритмы 1

//#include <iostream>
//#include <algorithm>
//#include <numeric>
//#include <vector>
//#include <utility>
//#include <cmath>
//
//using namespace std;
//
//int main() {
//    vector<pair<int, int>> points = { {2, 3}, {-4, 5}, {0, 0}, {1, 1}, {6, -2} };
//
//    // Удалить все точки из I четверти
//    points.erase(remove_if(points.begin(), points.end(), [](const pair<int, int>& p) {
//        return p.first > 0 && p.second > 0;
//        }), points.end());
//
//    // Подсчитать количество точек, у которых x и y совпадают
//    int count = count_if(points.begin(), points.end(), [](const pair<int, int>& p) {
//        return p.first == p.second;
//        });
//    cout << "Number of points where x and y are equal: " << count << endl;
//
//    // Найти наиболее удаленную от начала координат точку
//    auto farthest_point = *max_element(points.begin(), points.end(), [](const pair<int, int>& p1, const pair<int, int>& p2) {
//        return hypot(p1.first, p1.second) < hypot(p2.first, p2.second);
//        });
//    cout << "Farthest point from origin: (" << farthest_point.first << ", " << farthest_point.second << ")" << endl;
//
//    // Расположить точки в порядке возрастания координаты x
//    sort(points.begin(), points.end(), [](const pair<int, int>& p1, const pair<int, int>& p2) {
//        return p1.first < p2.first;
//        });
//    cout << "Points sorted by x coordinate: ";
//    for (auto& p : points) {
//        cout << "(" << p.first << ", " << p.second << ") ";
//    }
//    cout << endl;
//
//    return 0;
//}

//set 2

//#include <iostream>
//#include <set>
//#include <string>
//using namespace std;
//
//bool isPunctuation(char c) // функция, определяющая, является ли символ знаком препинания
//{
//    return (c == '.' || c == ',' || c == '!' || c == '?' || c == ':' || c == ';' || c == '-' || c == '(' || c == ')');
//}
//
//int main()
//{
//    int N;
//    cin >> N;
//
//    set<char> Punctuation; // множество знаков препинания из первой строки
//    string line;
//    getline(cin, line); // считываем первую строку
//    for (int i = 0; i < line.size(); i++)
//    {
//        if (isPunctuation(line[i])) // если символ - знак препинания
//        {
//            Punctuation.insert(line[i]); // добавляем его в множество
//        }
//    }
//
//    for (int i = 1; i < N; i++) // проходимся по остальным строкам
//    {
//        getline(cin, line);
//        for (int j = 0; j < line.size(); j++)
//        {
//            if (isPunctuation(line[j])) // если символ - знак препинания
//            {
//                if (Punctuation.find(line[j]) == Punctuation.end()) // если этот знак препинания не встречался в первой строке
//                {
//                    Punctuation.erase(line[j]); // удаляем его из множества
//                }
//            }
//        }
//    }
//
//    for (char c : Punctuation) // выводим результат
//    {
//        cout << c << " ";
//    }
//
//    return 0;
//}

//map 1

//#include <iostream>
//#include <fstream>
//#include <map>
//#include <string>
//using namespace std;
//
//int main()
//{
//    int k;
//    cin >> k;
//
//    map<int, int> numbersCount; // словарь для хранения количества вхождений чисел
//    string word;
//    ifstream inputFile("why.txt"); // открываем файл для чтения
//    while (inputFile >> word) // считываем слова из файла
//    {
//        if (isdigit(word[0])) // если первый символ - цифра
//        {
//            int number = stoi(word); // преобразуем строку в число
//            numbersCount[number]++; // увеличиваем счетчик вхождений числа
//        }
//    }
//    inputFile.close(); // закрываем файл
//
//    for (auto& pair : numbersCount) // проходимся по всем парам ключ-значение в словаре
//    {
//        if (pair.second == k) // если число встречается k раз
//        {
//            cout << pair.first << " "; // выводим его
//        }
//    }
//
//    return 0;
//}



//классы)

//#include <iostream>
//using namespace std;
//
//class Rectangle {
//private:
//    int a, b;
//public:
//    Rectangle(int a = 0, int b = 0) {
//        this->a = a;
//        this->b = b;
//    }
//
//    void printInfo() { // вывод информации о прямоугольнике
//        cout << "Rectangle: " << a << " x " << b << endl;
//    }
//
//    int perimeter() { // расчет периметра
//        return 2 * (a + b);
//    }
//
//    int area() { // расчет площади
//        return a * b;
//    }
//
//    void setSides(int a, int b) { // установка длин сторон
//        this->a = a;
//        this->b = b;
//    }
//
//    bool isSquare() { // проверка на квадрат
//        return a == b;
//    }
//
//    Rectangle operator++(int) { // перегрузка операции ++ (префиксная форма)
//        Rectangle temp(*this);
//        ++a;
//        ++b;
//        return temp;
//    }
//
//    Rectangle operator--() { // перегрузка операции -- (префиксная форма)
//        --a;
//        --b;
//        return *this;
//    }
//
//    Rectangle operator*(int scalar) { // перегрузка операции *
//        a *= scalar;
//        b *= scalar;
//        return *this;
//    }
//};
//
//int main() {
//    Rectangle r(5, 10);
//    r.printInfo(); // вывод информации о прямоугольнике
//
//    r++; // увеличение значений сторон на 1
//    r.printInfo(); // новые значения: 6 x 11
//
//    Rectangle s = --r; // уменьшение значений сторон на 1
//    s.printInfo(); // новые значения: 5 x 10
//
//    Rectangle t = r * 2; // умножение значений сторон на 2
//    t.printInfo(); // новые значения: 10 x 20
//
//    cout << "Perimeter: " << r.perimeter() << endl; // расчет периметра
//    cout << "Area: " << r.area() << endl; // расчет площади
//
//    r.setSides(5, 10); // установка значений сторон для квадрата
//    r.printInfo(); // вывод информации о квадрате
//    cout << "Is square? " << r.isSquare() << endl; // проверка на квадрат
//
//    return 0;
//}








//сортировки 1

//#include <iostream>
//#include <fstream>
//#include <vector>
//#include <algorithm>
//using namespace std;
//
//struct Student {
//    string surname, name, patronymic;
//    int birthYear;
//    vector<int> marks;
//    int sumMarks; // сумма оценок
//};
//
//// функция для чтения данных из файла
//void readDataFromFile(vector<Student>& students, int& groupNumber) {
//    ifstream fin("input.txt");
//    fin >> groupNumber;
//    while (!fin.eof()) {
//        Student s;
//        s.sumMarks = 0; // инициализация нулем
//        fin >> s.surname >> s.name >> s.patronymic >> s.birthYear;
//        for (int i = 0; i < 5; i++) {
//            int mark;
//            fin >> mark;
//            s.marks.push_back(mark);
//            s.sumMarks += mark;
//        }
//        students.push_back(s);
//    }
//    fin.close();
//}
//
//// функция для записи данных в файл
//void writeDataToFile(const vector<Student>& students, const int& groupNumber) {
//    ofstream fout("output.txt");
//    fout << groupNumber << "\n";
//    for (const auto& s : students) {
//        fout << s.surname << " " << s.name << " " << s.patronymic << " " << s.birthYear << " " << s.sumMarks << "\n";
//    }
//    fout.close();
//}
//
//// сортировка выбором
//void selectionSort(vector<Student>& students) {
//    for (int i = 0; i < students.size() - 1; i++) {
//        int minIndex = i;
//        for (int j = i + 1; j < students.size(); j++) {
//            if (students[j].sumMarks < students[minIndex].sumMarks) {
//                minIndex = j;
//            }
//        }
//        swap(students[i], students[minIndex]);
//    }
//}
//
//// сортировка вставками
//void insertionSort(vector<Student>& students) {
//    for (int i = 1; i < students.size(); i++) {
//        Student key = students[i];
//        int j = i - 1;
//        while (j >= 0 && students[j].sumMarks > key.sumMarks) {
//            students[j + 1] = students[j];
//            j--;
//        }
//        students[j + 1] = key;
//    }
//}
//
//// пузырьковая сортировка
//void bubbleSort(vector<Student>& students) {
//    for (int i = 0; i < students.size() - 1; i++) {
//        for (int j = 0; j < students.size() - 1 - i; j++) {
//            if (students[j].sumMarks > students[j + 1].sumMarks) {
//                swap(students[j], students[j + 1]);
//            }
//        }
//    }
//}
//
//int main() {
//    vector<Student> students;
//    int groupNumber;
//    readDataFromFile(students, groupNumber);
//
//    //selectionSort(students);
//    //insertionSort(students);
//    bubbleSort(students);
//
//    writeDataToFile(students, groupNumber);
//    return 0;
//}








//сортировки 2

//#include <iostream>
//using namespace std;
//
//// Функция быстрой сортировки
//void quickSort(int arr[], int left, int right) {
//    int i = left, j = right;
//    int tmp;
//    int pivot = arr[(left + right) / 2];
//
//    /* partition */
//    while (i <= j) {
//        while (arr[i] < pivot)
//            i++;
//        while (arr[j] > pivot)
//            j--;
//        if (i <= j) {
//            tmp = arr[i];
//            arr[i] = arr[j];
//            arr[j] = tmp;
//            i++;
//            j--;
//        }
//    };
//
//    /* recursion */
//    if (left < j)
//        quickSort(arr, left, j);
//    if (i < right)
//        quickSort(arr, i, right);
//}
//
//// Функция преобразования массива в кучу
//void heapify(int arr[], int n, int i) {
//    int largest = i; // Инициализируем наибольший элемент как корень
//    int l = 2 * i + 1; // левый = 2*i + 1
//    int r = 2 * i + 2; // правый = 2*i + 2
//
//    // Если левый дочерний элемент больше корня
//    if (l < n && arr[l] > arr[largest])
//        largest = l;
//
//    // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
//    if (r < n && arr[r] > arr[largest])
//        largest = r;
//
//    // Если самый большой элемент не корень
//    if (largest != i) {
//        swap(arr[i], arr[largest]);
//
//        // Рекурсивно кучафицируем затронутый поддерево
//        heapify(arr, n, largest);
//    }
//}
//
//// Функция сортировки кучей
//void heapSort(int arr[], int n) {
//    // Построение кучи (перегруппируем массив)
//    for (int i = n / 2 - 1; i >= 0; i--)
//        heapify(arr, n, i);
//
//    // Один за другим извлекаем элементы из кучи
//    for (int i = n - 1; i >= 0; i--) {
//        // Перемещаем текущий корень в конец
//        swap(arr[0], arr[i]);
//
//        // вызываем процедуру heapify на уменьшенной куче
//        heapify(arr, i, 0);
//    }
//}
//
//int main() {
//    int n = 3;
//    int matrix[3][3];
//
//    // Ввод матрицы
//    cout << "Enter the elements of matrix: " << endl;
//    for (int i = 0; i < n; i++) {
//        for (int j = 0; j < n; j++) {
//            cin >> matrix[i][j];
//        }
//    }
//
//    // Сортировка каждого столбца матрицы
//    for (int j = 0; j < n; j++) {
//        int col[3];
//        for (int i = 0; i < n; i++) {
//            col[i] = matrix[i][j];
//        }
//        //quickSort(col, 0, n-1); // Используем быструю сортировку
//        heapSort(col, n); // Используем сортировку кучей
//        for (int i = 0; i < n; i++) {
//            matrix[i][j] = col[i];
//        }
//    }
//
//    // Вывод отсортированной матрицы
//    cout << "Sorted matrix:" << endl;
//    for (int i = 0; i < n; i++) {
//        for (int j = 0; j < n; j++) {
//            cout << matrix[i][j] << " ";
//        }
//        cout << endl;
//    }
//
//    return 0;
//}
//
//сортировка кучей является более эффективной для данной задачи






//1-св. список

//#include <iostream>
//using namespace std;
//
//class Node {
//public:
//    int data;
//    Node* next;
//    Node(int d) { // конструктор для удобного создания элемента списка
//        data = d;
//        next = NULL;
//    }
//};
//
//class LinkedList {
//private:
//    Node* head;
//public:
//    LinkedList() { // конструктор для создания пустого списка
//        head = NULL;
//    }
//
//    void push(int new_data) { // функция добавления элемента в список
//        Node* new_node = new Node(new_data);
//        new_node->next = head;
//        head = new_node;
//    }
//
//    LinkedList copyList() { //создаем копию списка и возвращаем ее
//        LinkedList copy;
//        Node* temp = head;
//        while (temp != NULL) {
//            copy.push(temp->data);
//            temp = temp->next;
//        }
//        return copy;
//    }
//
//    void splitList(LinkedList& pos_list, LinkedList& neg_list) {
//        Node* temp = head;
//        while (temp != NULL) {
//            if (temp->data >= 0) {
//                pos_list.push(temp->data);
//            }
//            else {
//                neg_list.push(temp->data);
//            }
//            Node* prev = temp; // сохраняем указатель на предыдущий элемент
//            temp = temp->next;
//            delete prev; // удаляем элемент из изначального списка
//        }
//        head = NULL; // обнуляем указатель на голову списка
//    }
//
//    void printList() { // функция вывода списка
//        Node* node = head;
//        while (node != NULL) {
//            cout << node->data << " ";
//            node = node->next;
//        }
//    }
//};
//
//int main() {
//    LinkedList original_list;
//    LinkedList pos_list;
//    LinkedList neg_list;
//
//    original_list.push(1);
//    original_list.push(-7);
//    original_list.push(5);
//    original_list.push(-2);
//    original_list.push(3);
//
//    LinkedList copy = original_list.copyList();
//    copy.splitList(pos_list, neg_list);
//
//    cout << "Original List: ";
//    original_list.printList(); // 3 -2 5 -7 1
//    cout << endl;
//
//    cout << "Positive List: ";
//    pos_list.printList();
//    cout << endl;
//
//    cout << "Negative List: ";
//    neg_list.printList();
//    cout << endl;
//
//    return 0;
//}






//стек

//#include <iostream>
//#include <fstream>
//#include <stack>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    stack<int> positive, negative; // создаем два стека для положительных и отрицательных чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        if (num >= 0) { // если число положительное, добавляем в стек positive
//            positive.push(num);
//        }
//        else { // если число отрицательное, добавляем в стек negative
//            negative.push(num);
//        }
//    }
//    vector<int> result; // создаем вектор для записи результата
//    while (!positive.empty()) { // пока стек положительных чисел не пуст
//        result.push_back(positive.top()); // добавляем последнее число из стека в вектор
//        positive.pop(); // удаляем последнее число из стека
//    }
//    while (!negative.empty()) { // аналогично для стека отрицательных чисел
//        result.push_back(negative.top());
//        negative.pop();
//    }
//    for (int i = 0; i < n; i++) {
//        fout << result[i] << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//очередь

//#include <iostream>
//#include <fstream>
//#include <queue>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    queue<int> positive, negative; // создаем две очереди для положительных и отрицательных чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        if (num >= 0) { // если число положительное, добавляем в очередь positive
//            positive.push(num);
//        }
//        else { // если число отрицательное, добавляем в очередь negative
//            negative.push(num);
//        }
//    }
//    vector<int> result; // создаем вектор для записи результата
//    while (!positive.empty()) { // пока очередь положительных чисел не пуста
//        result.push_back(positive.front()); // добавляем первое число из очереди в вектор
//        positive.pop(); // удаляем первое число из очереди
//    }
//    while (!negative.empty()) { // аналогично для очереди отрицательных чисел
//        result.push_back(negative.front());
//        negative.pop();
//    }
//    for (int i = 0; i < n; i++) {
//        fout << result[i] << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//2-св. список

//#include <iostream>
//#include <fstream>
//#include <list>
//
//using namespace std;
//
//int main() {
//    ifstream fin("kapibara.txt"); // открываем файл для чтения
//    ofstream fout("kakibara.txt"); // открываем файл для записи
//    list<int> numbers; // создаем список для чисел
//    int n, num;
//    fin >> n; // считываем количество чисел в списке
//    for (int i = 0; i < n; i++) {
//        fin >> num; // считываем число
//        numbers.push_back(num); // добавляем число в конец списка
//    }
//    list<int> positive, negative; // создаем два списка для положительных и отрицательных чисел
//    for (auto it = numbers.begin(); it != numbers.end(); ++it) {
//        if (*it >= 0) { // если число положительное, добавляем в список positive
//            positive.push_back(*it);
//        }
//        else { // если число отрицательное, добавляем в список negative
//            negative.push_back(*it);
//        }
//    }
//    positive.splice(positive.end(), negative); // объединяем списки, перемещая все элементы из списка negative в конец списка positive
//    for (auto it = positive.begin(); it != positive.end(); ++it) {
//        fout << *it << " "; // записываем результат в файл
//    }
//    fin.close(); // закрываем файл для чтения
//    fout.close(); // закрываем файл для записи
//    return 0;
//}

//Vector 1

//#include <iostream>
//#include <vector>
//
//using namespace std;
//
//int main() {
//    vector<int> vec = { 1, 2, 3, 4, 5 };
//    int n = vec.size();
//
//    // заменяем средний элемент на сумму первого и последнего
//    vec[n / 2] = vec[0] + vec[n - 1];
//
//    // выводим измененный вектор
//    for (int i = 0; i < n; i++) {
//        cout << vec[i] << " ";
//    }
//
//    return 0;
//}
//
//Временная сложность для вектора : O(1), так как доступ к элементам вектора происходит за константное время.
//Выбор контейнера : вектор, так как нам нужен быстрый доступ к элементам по индексу.

//List 1

//#include <iostream>
//#include <list>
//
//using namespace std;
//
//int main() {
//    list<int> lst = { 1, 2, 3, 4, 5 };
//
//    // вставляем элемент x перед первым и последним элементами
//    lst.push_front(10);
//    lst.push_back(10);
//
//    // выводим измененный список
//    for (auto it = lst.begin(); it != lst.end(); it++) {
//        cout << *it << " ";
//    }
//
//    return 0;
//}
//
//Временная сложность для списка : O(1), так как вставка элемента в начало и конец списка происходит за константное время.
//Выбор контейнера : список, так как нам нужно быстро вставлять элементы в начало и конец списка.





//stable_sort

//#include <iostream>
//#include <fstream>
//#include <vector>
//#include <algorithm>
//
//using namespace std;
//
//struct Student {
//    string surname;
//    string name;
//    string patronymic;
//    int birth_year;
//    vector<int> marks;
//    int sum_marks = 0; // инициализация переменной sum_marks
//};
//
//bool compare(Student a, Student b) {
//    return a.sum_marks < b.sum_marks;
//}
//
//int main() {
//    ifstream input("input.txt");
//    ofstream output("output.txt");
//    int group_number;
//    input >> group_number;
//    output << "Group number: " << group_number << endl;
//    vector<Student> students;
//    while (!input.eof()) {
//        Student s;
//        input >> s.surname >> s.name >> s.patronymic >> s.birth_year;
//        s.marks.resize(5);
//        for (int i = 0; i < 5; i++) {
//            input >> s.marks[i];
//            s.sum_marks += s.marks[i];
//        }
//        students.push_back(s);
//    }
//    stable_sort(students.begin(), students.end(), compare);
//    for (Student s : students) {
//        output << s.surname << " " << s.name << " " << s.patronymic << " "
//            << s.birth_year << " " << s.sum_marks << endl;
//    }
//    input.close();
//    output.close();
//    return 0;
//}
//В отличие от sort, сортировка stable_sort гарантирует, что порядок элементов с одинаковыми 
//значениями ключа сортировки останется неизменным.Поэтому в данном коде лучше использовать 
//stable_sort, чтобы гарантировать правильный порядок элементов в отсортированном векторе.





//#include <iostream>
//#include <fstream>
//#include <algorithm>
//#include <vector>
//#include <string>
//
//using namespace std;
//
//struct Student {
//    string surname, name, patronymic;     //описываем информацию о студенте, включая его фамилию, имя, отчество, 
//    int birth_year, marks[5], sum_marks;  //год рождения, оценки по пяти предметам и сумму оценок.
//};
//
//bool compare(const Student& a, const Student& b) {
//    return a.sum_marks < b.sum_marks;  //сравниваем студентов по сумме оценок и используется при сортировке.
//}
//
//int main() {                          //считывается информация из файла input.txt, 
//    ifstream input("input.txt");      //создается вектор студентов, для каждого студента вычисляется 
//    ofstream output("output.txt");    //сумма оценок и записывается информация о нем в вектор.
//    vector<Student> students;
//    string group_number;
//    while (input >> group_number) {
//        string surname, name, patronymic;
//        int birth_year, marks[5];
//        int sum_marks = 0;
//        input >> surname >> name >> patronymic >> birth_year;
//        for (int i = 0; i < 5; i++) {
//            input >> marks[i];
//            sum_marks += marks[i];
//        }
//        students.push_back({ surname, name, patronymic, birth_year, {marks[0], marks[1], marks[2], marks[3], marks[4]}, sum_marks });
//    }
//    stable_sort(students.begin(), students.end(), compare);  //Студенты сортируются по возрастанию суммы оценок
//    for (auto& student : students) {
//        output << student.surname << " " << student.name << " " << student.patronymic << " " << student.sum_marks << endl;
//    }
//    return 0;
//}

//алгоритмы 1

//#include <iostream>
//#include <algorithm>
//#include <numeric>
//#include <vector>
//#include <utility>
//#include <cmath>
//
//using namespace std;
//
//int main() {
//    vector<pair<int, int>> points = { {2, 3}, {-4, 5}, {0, 0}, {1, 1}, {6, -2} };
//
//    // Удалить все точки из I четверти
//    points.erase(remove_if(points.begin(), points.end(), [](const pair<int, int>& p) {
//        return p.first > 0 && p.second > 0;
//        }), points.end());
//
//    // Подсчитать количество точек, у которых x и y совпадают
//    int count = count_if(points.begin(), points.end(), [](const pair<int, int>& p) {
//        return p.first == p.second;
//        });
//    cout << "Number of points where x and y are equal: " << count << endl;
//
//    // Найти наиболее удаленную от начала координат точку
//    auto farthest_point = *max_element(points.begin(), points.end(), [](const pair<int, int>& p1, const pair<int, int>& p2) {
//        return hypot(p1.first, p1.second) < hypot(p2.first, p2.second);
//        });
//    cout << "Farthest point from origin: (" << farthest_point.first << ", " << farthest_point.second << ")" << endl;
//
//    // Расположить точки в порядке возрастания координаты x
//    sort(points.begin(), points.end(), [](const pair<int, int>& p1, const pair<int, int>& p2) {
//        return p1.first < p2.first;
//        });
//    cout << "Points sorted by x coordinate: ";
//    for (auto& p : points) {
//        cout << "(" << p.first << ", " << p.second << ") ";
//    }
//    cout << endl;
//
//    return 0;
//}

//set 2

//#include <iostream>
//#include <set>
//#include <string>
//using namespace std;
//
//bool isPunctuation(char c) // функция, определяющая, является ли символ знаком препинания
//{
//    return (c == '.' || c == ',' || c == '!' || c == '?' || c == ':' || c == ';' || c == '-' || c == '(' || c == ')');
//}
//
//int main()
//{
//    int N;
//    cin >> N;
//
//    set<char> Punctuation; // множество знаков препинания из первой строки
//    string line;
//    getline(cin, line); // считываем первую строку
//    for (int i = 0; i < line.size(); i++)
//    {
//        if (isPunctuation(line[i])) // если символ - знак препинания
//        {
//            Punctuation.insert(line[i]); // добавляем его в множество
//        }
//    }
//
//    for (int i = 1; i < N; i++) // проходимся по остальным строкам
//    {
//        getline(cin, line);
//        for (int j = 0; j < line.size(); j++)
//        {
//            if (isPunctuation(line[j])) // если символ - знак препинания
//            {
//                if (Punctuation.find(line[j]) == Punctuation.end()) // если этот знак препинания не встречался в первой строке
//                {
//                    Punctuation.erase(line[j]); // удаляем его из множества
//                }
//            }
//        }
//    }
//
//    for (char c : Punctuation) // выводим результат
//    {
//        cout << c << " ";
//    }
//
//    return 0;
//}

//map 1

//#include <iostream>
//#include <fstream>
//#include <map>
//#include <string>
//using namespace std;
//
//int main()
//{
//    int k;
//    cin >> k;
//
//    map<int, int> numbersCount; // словарь для хранения количества вхождений чисел
//    string word;
//    ifstream inputFile("why.txt"); // открываем файл для чтения
//    while (inputFile >> word) // считываем слова из файла
//    {
//        if (isdigit(word[0])) // если первый символ - цифра
//        {
//            int number = stoi(word); // преобразуем строку в число
//            numbersCount[number]++; // увеличиваем счетчик вхождений числа
//        }
//    }
//    inputFile.close(); // закрываем файл
//
//    for (auto& pair : numbersCount) // проходимся по всем парам ключ-значение в словаре
//    {
//        if (pair.second == k) // если число встречается k раз
//        {
//            cout << pair.first << " "; // выводим его
//        }
//    }
//
//    return 0;
//}





// vector list 2

//#include <iostream>
//#include <vector>
//#include <string>
//using namespace std;
//
//// Класс книги
//class Book {
//private:
//    string title;
//    string author;
//    int ageLimit;
//public:
//    Book(string t, string a, int al) {
//        title = t;
//        author = a;
//        ageLimit = al;
//    }
//    void setAgeLimit(int al) {
//        ageLimit = al;
//    }
//    void print() {
//        cout << "Title: " << title << ", Author: " << author << ", Age Limit: " << ageLimit << endl;
//    }
//    string getAuthor() {
//        return author;
//    }
//};
//
//// Класс библиотеки
//class Library {
//private:
//    vector<Book> books;
//public:
//    void addBook(Book b) {
//        books.push_back(b);
//    }
//    void markAuthorBooksAsAdult(string author) {
//        for (int i = 0; i < books.size(); i++) {
//            if (books[i].getAuthor() == author) {
//                books[i].setAgeLimit(18);
//            }
//        }
//    }
//    void swapLastTwoBooks() {
//        if (books.size() >= 2) {
//            Book temp = books[books.size() - 1];
//            books[books.size() - 1] = books[books.size() - 2];
//            books[books.size() - 2] = temp;
//        }
//    }
//    void removeAuthorBooks(string author) {
//        for (int i = 0; i < books.size(); i++) {
//            if (books[i].getAuthor() == author) {
//                books.erase(books.begin() + i);
//                i--;
//            }
//        }
//    }
//    void swapFirstAndLastBooks() {
//        if (books.size() >= 2) {
//            Book temp = books[0];
//            books[0] = books[books.size() - 1];
//            books[books.size() - 1] = temp;
//        }
//    }
//    void printAllBooks() {
//        for (int i = 0; i < books.size(); i++) {
//            books[i].print();
//        }
//    }
//};
//
//int main() {
//    Library library;
//
//    // Добавляем несколько книг
//    library.addBook(Book("War and Peace", "Leo Tolstoy", 18));
//    library.addBook(Book("Crime and Punishment", "Fyodor Dostoevsky", 18));
//    library.addBook(Book("The Great Gatsby", "F. Scott Fitzgerald", 18));
//    library.addBook(Book("To Kill a Mockingbird", "Harper Lee", 18));
//    library.addBook(Book("1984", "George Orwell", 18));
//
//    // Выводим все книги
//    cout << "All books in library: " << endl;
//    library.printAllBooks();
//
//    // Отмечаем книги Льва Толстого как 18+
//    library.markAuthorBooksAsAdult("Leo Tolstoy");
//
//    // Меняем местами две последние книги
//    library.swapLastTwoBooks();
//
//    // Выводим все книги после изменений
//    cout << "All books in library after marking Tolstoy's books as 18+ and swapping last two books: " << endl;
//    library.printAllBooks();
//
//    // Удаляем книги Харпер Ли
//    library.removeAuthorBooks("Harper Lee");
//
//    // Меняем местами первую и последнюю книги
//    library.swapFirstAndLastBooks();
//
//    // Выводим все книги после изменений
//    cout << "All books in library after removing Harper Lee's books and swapping first and last books: " << endl;
//    library.printAllBooks();
//
//    return 0;
//}





//алгоритмы 2

//#include <iostream>
//#include <vector>
//#include <algorithm>
//
//using namespace std;
//
//// Создаем класс "звук"
//class Sound {
//public:
//    int noteHeight; // высота ноты
//    int duration; // длительность звучания
//};
//
//// Создаем мелодии
//vector<Sound> melody1 = { {1, 2}, {2, 3}, {3, 4}, {4, 5} };
//vector<Sound> melody2 = { {2, 3}, {4, 5}, {1, 2}, {3, 4} };
//
//// Проверяем, содержатся ли все звуки одной мелодии в другой мелодии
//bool checkMelodies(vector<Sound> melody1, vector<Sound> melody2) {
//    return melody1.size() == melody2.size() && equal(melody1.begin(), melody1.end(), melody2.begin(), [](const Sound& s1, const Sound& s2) {
//        return s1.noteHeight == s2.noteHeight && s1.duration == s2.duration;
//        });
//}
//
//int main() {
//    // Пример:
//    // melody1: {1, 2}, {2, 3}, {3, 4}, {4, 5}
//    // melody2: {2, 3}, {4, 5}, {1, 2}, {3, 4}
//    // Результат: true, так как все звуки одной мелодии содержатся в другой мелодии
//    cout << checkMelodies(melody1, melody2) << endl;
//
//    // melody1: {1, 2}, {2, 3}, {3, 4}, {4, 5}
//    // melody2: {2, 3}, {4, 5}, {1, 2}, {4, 4}
//    // Результат: false, так как один из звуков не совпадает
//    cout << checkMelodies(melody1, { {2, 3}, {4, 5}, {1, 2}, {4, 4} }) << endl;
//
//    return 0;
//}





// vector list 2

//#include <iostream>
//#include <vector>
//#include <string>
//using namespace std;
//
//// Класс книги
//class Book {
//private:
//    string title;
//    string author;
//    int ageLimit;
//public:
//    Book(string t, string a, int al) {
//        title = t;
//        author = a;
//        ageLimit = al;
//    }
//    void setAgeLimit(int al) {
//        ageLimit = al;
//    }
//    void print() {
//        cout << "Title: " << title << ", Author: " << author << ", Age Limit: " << ageLimit << endl;
//    }
//    string getAuthor() {
//        return author;
//    }
//};
//
//// Класс библиотеки
//class Library {
//private:
//    vector<Book> books;
//public:
//    void addBook(Book b) {
//        books.push_back(b);
//    }
//    void markAuthorBooksAsAdult(string author) {
//        for (int i = 0; i < books.size(); i++) {
//            if (books[i].getAuthor() == author) {
//                books[i].setAgeLimit(18);
//            }
//        }
//    }
//    void swapLastTwoBooks() {
//        if (books.size() >= 2) {
//            Book temp = books[books.size() - 1];
//            books[books.size() - 1] = books[books.size() - 2];
//            books[books.size() - 2] = temp;
//        }
//    }
//    void removeAuthorBooks(string author) {
//        for (int i = 0; i < books.size(); i++) {
//            if (books[i].getAuthor() == author) {
//                books.erase(books.begin() + i);
//                i--;
//            }
//        }
//    }
//    void swapFirstAndLastBooks() {
//        if (books.size() >= 2) {
//            Book temp = books[0];
//            books[0] = books[books.size() - 1];
//            books[books.size() - 1] = temp;
//        }
//    }
//    void printAllBooks() {
//        for (int i = 0; i < books.size(); i++) {
//            books[i].print();
//        }
//    }
//};
//
//int main() {
//    Library library;
//
//    // Добавляем несколько книг
//    library.addBook(Book("War and Peace", "Leo Tolstoy", 18));
//    library.addBook(Book("Crime and Punishment", "Fyodor Dostoevsky", 18));
//    library.addBook(Book("The Great Gatsby", "F. Scott Fitzgerald", 18));
//    library.addBook(Book("To Kill a Mockingbird", "Harper Lee", 18));
//    library.addBook(Book("1984", "George Orwell", 18));
//
//    // Выводим все книги
//    cout << "All books in library: " << endl;
//    library.printAllBooks();
//
//    // Отмечаем книги Льва Толстого как 18+
//    library.markAuthorBooksAsAdult("Leo Tolstoy");
//
//    // Меняем местами две последние книги
//    library.swapLastTwoBooks();
//
//    // Выводим все книги после изменений
//    cout << "All books in library after marking Tolstoy's books as 18+ and swapping last two books: " << endl;
//    library.printAllBooks();
//
//    // Удаляем книги Харпер Ли
//    library.removeAuthorBooks("Harper Lee");
//
//    // Меняем местами первую и последнюю книги
//    library.swapFirstAndLastBooks();
//
//    // Выводим все книги после изменений
//    cout << "All books in library after removing Harper Lee's books and swapping first and last books: " << endl;
//    library.printAllBooks();
//
//    return 0;
//}





//алгоритмы 2

//#include <iostream>
//#include <vector>
//#include <algorithm>
//
//using namespace std;
//
//// Создаем класс "звук"
//class Sound {
//public:
//    int noteHeight; // высота ноты
//    int duration; // длительность звучания
//};
//
//// Создаем мелодии
//vector<Sound> melody1 = { {1, 2}, {2, 3}, {3, 4}, {4, 5} };
//vector<Sound> melody2 = { {2, 3}, {4, 5}, {1, 2}, {3, 4} };
//
//// Проверяем, содержатся ли все звуки одной мелодии в другой мелодии
//bool checkMelodies(vector<Sound> melody1, vector<Sound> melody2) {
//    return melody1.size() == melody2.size() && equal(melody1.begin(), melody1.end(), melody2.begin(), [](const Sound& s1, const Sound& s2) {
//        return s1.noteHeight == s2.noteHeight && s1.duration == s2.duration;
//        });
//}
//
//int main() {
//    // Пример:
//    // melody1: {1, 2}, {2, 3}, {3, 4}, {4, 5}
//    // melody2: {2, 3}, {4, 5}, {1, 2}, {3, 4}
//    // Результат: true, так как все звуки одной мелодии содержатся в другой мелодии
//    cout << checkMelodies(melody1, melody2) << endl;
//
//    // melody1: {1, 2}, {2, 3}, {3, 4}, {4, 5}
//    // melody2: {2, 3}, {4, 5}, {1, 2}, {4, 4}
//    // Результат: false, так как один из звуков не совпадает
//    cout << checkMelodies(melody1, { {2, 3}, {4, 5}, {1, 2}, {4, 4} }) << endl;
//
//    return 0;
//}
