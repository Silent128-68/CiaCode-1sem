#pragma once

namespace Tishchenko {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;


	float lines[] = {
		// голова
		0.5f,3.f,1.f,4.5f, // от левой щеки вверх до уха
		1.f,4.5f,0.5f,6.f, // левое ухо слева снизу вверх
		0.5f,6.f,0.5f, 7.5f, // левое ухо слева
		0.5f, 7.5f,1.f,8.f, // левое ухо верх слева
		1.f,8.f,1.5f,8.f, // левое ухо верх середина
		1.5f,8.f,2.f,7.5f, // левое ухо верх справа
		2.f,7.5f,1.5f, 6.f, // левое ухо справа сверху вниз
		1.5f, 6.f,1.5f,4.5f, // левое ухо справа до макушки
		1.5f,4.5f,3.f,4.5f, // макушка
		3.f,4.5f,3.f,6.f, // правое ухо слева снизу вверх
		3.f,6.f,2.5f,7.5f, // правое ухо слева
		2.5f,7.5f,3.f,8.f, // правое ухо верх слева
		3.f,8.f,3.5f,8.f, // правое ухо верх середина
		3.5f,8.f,4.f,7.5f, // правое ухо верх справа
		4.f,7.5f,4.f,6.f, // правое ухо сверху вниз
		4.f,6.f,3.5f,4.5f, // правое ухо справа
		3.5f,4.5f,4.f,3.f, // от правого уха вниз до щеки
		4.f,3.f,3.5f,1.5f, // правая скула
		3.5f,1.5f,2.5f,1.f, // подбородок справа
		2.5f,1.f,2.f,1.f, // подбородок снизу
		2.f,1.f,1.f,1.5f, // подбородок слева
		1.f,1.5f,0.5f,3.f, // левая скула
		// туловище
		4.f,3.f,5.5f,3.5f, // спина от головы вправо
		5.5f,3.5f,7.f,3.5f, // спина верх
		7.f,3.5f,7.5f,2.5f, // спина сверху до хвоста
		7.5f,2.5f,8.f,2.5f, // хвост сверху
		8.f,2.5f,8.f,2.f, // хвост справа
		8.f,2.f,7.5f,2.f, // хвост низ справа налево
		7.5f,2.f,7.5f,0.5f, // задняя нога справа сверху вниз
		7.5f,0.5f,6.5f,0.5f, // задняя нога низ
		6.5f,0.5f,6.5f,1.f, // задняя нога слева
		6.5f,1.f,6.f,1.f, // между задних ног
		6.f,1.f,6.f,0.5f, // левая задняя нога справа
		6.f,0.5f,5.f,0.5f, // левая задняя нога низ
		5.f,0.5f,5.f,1.f, // левая задняя нога слева
		5.f,1.f,4.f,1.f, // между задними и передними ногами
		4.f,1.f,4.f,0.5f, // правая передняя нога справа
		4.f,0.5f,3.f,0.5f, // правая передняя нога низ
		3.f,0.5f,3.f,1.f, // правая передняя нога слева
		3.f,1.f,2.5f,1.f, // между передних ног
		2.5f,1.f,2.5f,0.5f, // передняя нога справа
		2.5f,0.5f,1.5f,0.5f, // передняя нога низ
		1.5f,0.5f,1.5f,1.25f, // передняя нога слева
		// левый глаз
		1.5f,3.5f,1.5f,3.f, // левый глаз слева сверху вниз
		1.5f,3.f,2.f,3.f, // левый глаз низ
		2.f, 3.f,2.f,3.5f, // левый глаз справа
		2.f,3.5f,1.5f,3.5f, // левый глаз верх
		// правый глаз
		2.5f,3.5f,2.5f,3.f, // правый глаз слева
		2.5f,3.f,3.f, 3.f, // правый глаз снизу
		3.f,3.f,3.f,3.5f, // правый глаз справа
		3.f,3.5f,2.5f,3.5f, // правый глаз сверху
		// ушные раковины
		1.f,5.5f,1.f,7.f, // левая ушная раковина
		3.5f,5.5f,3.5f,7.f, // правая ушная раковина
		// нос
		2.f,2.5f,2.5f,2.5f, // нос сверху
		2.5f,2.5f,2.25f,2.f, // нос справа
		2.25f,2.f,2.f,2.5f // нос слева
	};


	float lines2[] = {
		// Яблоко
		0.5f, 2.5f, 0.5f, 3.5f, // левая сторона яблока
		0.5f, 3.5f, 1.5f, 5.f, // вверх направо
		1.5f, 5.f, 2.f, 4.5f, // вправо вниз
		2.f, 4.5f, 2.f, 5.25f, // вверх
		2.f, 5.25f, 2.5f, 5.5f, // вверх вправо
		2.83f, 5.5f, 3.5f, 5.5f, // через 0.5 вправо
		3.5f, 5.5f, 3.f, 5.f, // вниз влево
		3.f, 5.f, 3.5f, 4.5f, // вниз вправо
		3.5f, 4.5f, 2.5f, 4.5f, // влево
		2.5f, 4.5f, 2.f, 5.f, // вверх влево
		3.f, 5.f, 2.f, 6.f, // палочка вверх влево
		2.f, 6.f, 2.5f, 6.5f, // палочка вверх вправо
		2.5f, 6.5f, 3.f, 5.f, // завершение палочки вниз вправо
		3.5f, 4.5f, 4.f, 4.f, // яблоко вниз вправо
		4.f, 4.f, 4.5f, 4.5f, // вверх вправо
		4.5f, 4.5f, 5.f, 3.5f, // вниз вправо
		5.f, 3.5f, 4.f, 3.f, // вниз влево
		4.f, 3.f, 3.5f, 4.f, // вверх влево
		3.5f, 4.f, 2.5f, 3.5f, // вниз влево
		2.5f, 3.5f, 2.f, 2.f, // вниз влево
		2.f, 2.f, 2.75f, 1.f, // вниз вправо
		2.75f, 1.f, 1.5f, 1.f, // влево
		1.5f, 1.f, 0.5f, 2.5f, // завершение яблока вверх влево
		// Ноги
		2.75f, 1.f, 3.f, 0.5f, // ботинок вниз вправо от нижней правой части яблока
		3.f, 0.5f, 5.f, 1.f, // ботинок вверх вправо
		5.f, 1.f, 4.f, 3.f, // ботинок вверх влево
		4.f, 3.f, 5.f, 3.5f, // штаны вверх влево от конца ботинка
		4.75f, 4.f, 7.8f, 4.f, // штаны вправо
		7.8f, 4.f, 7.5f, 2.5f, // штаны вниз влево
		7.5f, 2.5f, 7.f, 2.f, // штаны вниз влево
		7.f, 2.f, 7.f, 1.5f, // штаны вниз
		7.f, 1.5f, 5.f, 1.f, // завершение штанов вниз влево
		// Туловище
		7.8f, 4.f, 8.f, 4.5f, // спина вверх вправо
		8.f, 4.5f, 7.5f, 6.5f, // спина вверх влево
		7.5f, 6.5f, 6.5f, 7.5f, // спина вверх влево
		6.5f, 7.5f, 6.f, 7.f, // верх туловища вниз влево
		6.f, 7.f, 3.f, 5.5f, // верх туловища вниз влево
		2.5f, 5.5f, 1.5f, 5.5f, // рука слева от яблока влево от палочки
		1.5f, 5.5f, 1.5f, 5.f, // завершение руки слева от яблока вниз завершение
		6.5f, 4.5f, 4.5f, 4.5f, // начало руки справа от яблока с правой нижней части влево
		5.5f, 4.5f, 5.5f, 5.75f, // рукав правой руки ввверх
		6.5f, 6.f, 4.5f, 5.5f, // верх правой руки вниз влево
		4.5f, 5.5f, 5.f, 6.5f, // вверх вправо
		4.5f, 5.5f, 4.f, 6.f, // вверх влево правой руки
		4.f, 6.f, 3.5f, 5.5f, // вниз влево
		// Голова
		5.f, 6.5f, 3.5f, 7.f, // вверх влево
		3.5f, 7.f, 1.5f, 8.f, // вверх влево
		1.5f, 8.f, 1.f, 7.5f, // нос вниз влево
		1.f, 7.5f, 0.5f, 8.5f, // нос вверх влево
		0.5f, 8.5f, 1.5f, 8.5f, // нос влево
		1.5f, 8.5f, 1.5f, 8.f, // нос вниз
		1.5f, 8.5f, 3.f, 9.f, // голова от носа вверх вправо
		3.f, 9.f, 3.5f, 10.f, // голова вверх вправо
		3.5f, 10.f, 4.5f, 11.f, // голова вверх вправо
		3.5f, 10.f, 4.5f, 10.f, // верх глаза вправо
		4.5f, 10.f, 4.f, 8.5f, // глаз вниз влево
		4.f, 8.5f, 3.f, 9.f, // глаз вверх влево
		3.f, 9.f, 3.5f, 9.f, // глаз вправо
		3.5f, 9.f, 4.f, 10.f, // глаз вверх вправо
		4.5f, 11.f, 5.5f, 11.5f, // затылок вверх вправо
		5.5f, 11.5f, 5.f, 10.f, // затылок вниз влево
		5.f, 10.f, 6.f, 11.f, // затылок вверх вправо
		6.f, 11.f, 5.5f, 9.f, // затылок вниз влево
		5.5f, 9.f, 6.5f, 9.5f, // затылок вверх вправо
		6.5f, 9.5f, 6.f, 8.f, // затылок вниз влево
		6.f, 8.f, 7.f, 8.5f, // затылок вверх вправо
		7.f, 8.5f, 6.5f, 7.5f, // затылок вниз влево
		3.5f, 7.f, 5.f, 8.f, // улыбка вверх вправо
		5.f, 8.f, 5.f, 8.5f, // улыбка вверх
		// Иголки
		4.5f, 11.f, 3.5f, 10.5f, // по часовой
		3.5f, 10.5f, 4.f, 11.5f,
		4.f, 11.5f, 2.5f, 11.f,
		2.5f, 11.f, 4.f, 12.5f,
		4.f, 12.5f, 3.f, 13.5f,
		3.f, 13.5f, 4.5f, 13.f,
		4.5f, 13.f, 5.f, 14.f,
		5.f, 14.f, 5.5f, 13.f,
		5.5f, 13.f, 7.f, 14.f,
		7.f, 14.f, 7.f, 13.f,
		7.f, 13.f, 8.5f, 13.5f,
		8.5f, 13.5f, 8.f, 12.5f,
		8.f, 12.5f, 9.5f, 12.f,
		9.5f, 12.f, 8.5f, 11.5f,
		8.5f, 11.5f, 10.f, 10.5f,
		10.f, 10.5f, 10.25f, 10.f,
		10.25f, 10.f, 9.5f, 10.f,
		9.5f, 10.f, 10.f, 8.5f,
		10.f, 8.5f, 9.f, 8.5f,
		9.f, 8.5f, 10.f, 8.f,
		10.f, 8.f, 9.f, 7.5f,
		9.f, 7.5f, 10.f, 7.f,
		10.f, 7.f, 9.f, 6.5f,
		9.f, 6.5f, 10.f, 5.5f,
		10.f, 5.5f, 8.5f, 5.f,
		8.5f, 5.f, 10.f, 4.5f,
		10.f, 4.5f, 9.f, 4.f,
		9.f, 4.f, 10.f, 3.f,
		10.f, 3.f, 9.f, 2.5f,
		9.f, 2.5f, 10.f, 2.f,
		10.f, 2.f, 9.f, 1.4f,
		7.5f, 2.5f, 9.5f, 1.f,
		9.5f, 1.f, 7.f, 1.5f, // завершение иголок снизу справа
	};

	unsigned int arrayLength2 = sizeof(lines2) / sizeof(float);
	float Vx = 10.5f; // размер рисунка по горизонтали
	float Vy = 14.5f; // размер рисунка по вертикали
	float aspectFig = Vx / Vy; // соотношение сторон рисунка

	unsigned int arrayLength = sizeof(lines) / sizeof(float);


	/// <summary>
	/// Сводка для MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(284, 261);
			this->DoubleBuffered = true;
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::MyForm_Paint);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::MyForm_KeyDown);
			this->Resize += gcnew System::EventHandler(this, &MyForm::MyForm_Resize);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: bool keepAspectRatio; // значение - сохранять ли соотношение сторон рисунка?
	private: bool showHedgehog;

	private: System::Void MyForm_Paint(System::Object^ sender, System::Windows::Forms::PaintEventArgs^ e) {
		Graphics^ g = e->Graphics;
		g->Clear(Color::Aquamarine);

		Pen^ blackPen = gcnew Pen(Color::Black, 2);

		float Wx = ClientRectangle.Width; // размер окна по горизонтали
		float Wy = ClientRectangle.Height; // размер окна по вертикали

		float aspectForm = Wx / Wy; // соотношение сторон окна рисования
		float Sx, Sy;
		if (keepAspectRatio) {
			// коэффициенты увеличения при сохранении исходного соотношения сторон
			Sx = Sy = aspectFig < aspectForm ? Wy / Vy : Wx / Vx;
		}
		else {
			Sx = Wx / Vx; // коэффициент увеличения по оси Ox
			Sy = Wy / Vy; // коэффициент увеличения по оси Oy
		}
		float Ty = Sy * Vy; // смещение в положительную сторону по оси Oy после смены знака
		if (showHedgehog) {
			for (int i = 0; i < arrayLength2; i += 4) {
				g->DrawLine(blackPen, Sx * lines2[i], Ty - Sy * lines2[i + 1], Sx * lines2[i + 2], Ty - Sy * lines2[i + 3]);
			}
		}
		else {
			for (int i = 0; i < arrayLength; i += 4) {
				g->DrawLine(blackPen, Sx * lines[i], Ty - Sy * lines[i + 1], Sx * lines[i + 2], Ty - Sy * lines[i + 3]);
			}
		}
	}

	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
		keepAspectRatio = true; // начальное значение: сохранять соотношение сторон рисунка
	}

	private: System::Void MyForm_KeyDown(System::Object^ sender, System::Windows::Forms::KeyEventArgs^ e) {
		switch (e->KeyCode) {
		case Keys::M:
			keepAspectRatio = !keepAspectRatio;
			break;
		case Keys::N:
			showHedgehog = !showHedgehog;
			break;
		default:
			break;
		}
		Refresh();
	}

	private: System::Void MyForm_Resize(System::Object^ sender, System::EventArgs^ e) {
		Refresh();
	}
	};
}
