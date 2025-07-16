import numpy as np
import os
import pytz
from tensorflow.keras.models import load_model
from tensorflow.keras.losses import MeanSquaredError
from ipywidgets import widgets, Layout
from IPython.display import display

def load_training_data():
    """Загрузка данных из input.txt, использованных при обучении"""
    if not os.path.exists('input.txt'):
        raise FileNotFoundError("Файл input.txt не найден")
    with open('input.txt', 'r') as f:
        columns = eval(f.readline())
        data = np.array(eval(f.readline()))
    return columns, data

def find_closest_row(user_input, input_columns, X_train_norm):
    """Поиск ближайшей строки в тренировочных данных"""
    # Создаем маску для указанных пользователем параметров
    mask = [col in user_input for col in input_columns]

    # Нормализация введенных данных
    params = np.load('preprocessing_params.npz')
    user_values_norm = [
        (float(user_input[col]) - params['X_mean'][idx]) / (params['X_std'][idx] + 1e-8)
        for idx, col in enumerate(input_columns) if col in user_input
    ]

    # Вычисление расстояний
    distances = np.sqrt(
        np.sum(
            (X_train_norm[:, mask] - user_values_norm)**2,
            axis=1
        )
    )
    return np.argmin(distances)

def predict():
    # Проверка наличия модели и данных
    if not all(os.path.exists(f) for f in ['my_model.h5', 'preprocessing_params.npz', 'selected_columns.txt']):
        print("Ошибка: Сначала обучите модель!")
        return

    # Загрузка метаданных
    params = np.load('preprocessing_params.npz')
    input_columns = [col for idx, col in enumerate(params['columns'])
                    if idx not in params['target_indices']]

    # Загрузка тренировочных данных
    train_columns, train_data = load_training_data()
    X_train = np.delete(train_data, params['target_indices'], axis=1)
    X_train_norm = (X_train - params['X_mean']) / (params['X_std'] + 1e-8)

    # Создание виджетов
    input_widgets = {
        col: widgets.Text(
            description=f"{col}:",
            layout=Layout(width='400px'),
            placeholder='Оставьте пустым, если параметр не учитываем'
        ) for col in input_columns
    }

    predict_btn = widgets.Button(description="Предсказать")
    output = widgets.Output()

    def on_predict_click(b):
        try:
            # Сбор введенных данных
            user_input = {
                col: widget.value.strip()
                for col, widget in input_widgets.items()
                if widget.value.strip()
            }

            if not user_input:
                raise ValueError("Введите хотя бы один параметр")

            # Поиск ближайшей строки
            closest_idx = find_closest_row(user_input, input_columns, X_train_norm)
            full_input = train_data[closest_idx].copy()

            # Замена указанных пользователем значений
            for col, value in user_input.items():
                idx = train_columns.index(col)
                full_input[idx] = float(value)

            # Нормализация и предсказание
            input_vector = np.delete(full_input, params['target_indices'])
            input_norm = (input_vector - params['X_mean']) / (params['X_std'] + 1e-8)

            model = load_model('my_model.h5', compile=False)
            model.compile(optimizer='adam', loss=MeanSquaredError())
            prediction = model.predict(input_norm.reshape(1, -1))

            # Получение действительных значений из ближайшей строки
            actual_values = full_input[params['target_indices']]

            # Расчет погрешности
            errors = abs(prediction[0] - actual_values)
            relative_errors = errors / (actual_values + 1e-8) * 100  # В процентах

            # Формирование результата
            with open('selected_columns.txt') as f:
                target_columns = eval(f.read())

            result = []
            result.append("\nРЕЗУЛЬТАТЫ ПРЕДСКАЗАНИЯ:")
            for col, pred, actual, err, rel_err in zip(target_columns, prediction[0], actual_values, errors, relative_errors):
                result.append(f"{col}:")
                result.append(f"  Предсказано: {pred:.2f}")
                result.append(f"  Действительное: {actual:.2f}")
                result.append(f"  Абс. ошибка: {err:.2f}")
                result.append(f"  Отн. ошибка: {rel_err:.2f}%")

            # Вывод в интерфейс
            with output:
                output.clear_output()
                print("\n".join(result))

            # Кнопка для сохранения в файл
            save_btn = widgets.Button(description="Сохранить в файл")
            save_output = widgets.Output()

            def on_save_click(b):
                try:
                    # Получаем текущее время с учетом часового пояса
                    timestamp = datetime.now(pytz.timezone('Europe/Moscow')).strftime("%Y%m%d_%H%M%S")
                    filename = f"prediction_{timestamp}.txt"

                    with open(filename, 'w', encoding='utf-8') as f:
                        f.write("РЕЗУЛЬТАТЫ АНАЛИЗА\n")
                        f.write(f"Дата: {datetime.now(pytz.timezone('Europe/Moscow')).strftime('%d.%m.%Y %H:%M:%S')}\n\n")
                        f.write("\n".join(result))

                    with save_output:
                        save_output.clear_output()
                        print(f"Файл {filename} успешно сохранен!")

                except Exception as e:
                    with save_output:
                        save_output.clear_output()
                        print(f"Ошибка при сохранении: {str(e)}")

            save_btn.on_click(on_save_click)

            with output:
                display(save_btn)
                display(save_output)

        except Exception as e:
            with output:
                output.clear_output()
                print(f"Ошибка: {str(e)}")

    predict_btn.on_click(on_predict_click)

    # Отображение интерфейса
    display(widgets.VBox([
        widgets.Label("Введите известные параметры:"),
        *input_widgets.values(),
        predict_btn,
        output
    ]))

if __name__ == "__main__":
    predict()