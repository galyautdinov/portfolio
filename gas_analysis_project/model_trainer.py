import numpy as np
import os
from tensorflow.keras.models import Sequential, load_model
from tensorflow.keras.layers import Dense, Input, BatchNormalization, Dropout
from tensorflow.keras.regularizers import L1L2
from tensorflow.keras.callbacks import EarlyStopping, ReduceLROnPlateau
from ipywidgets import widgets, Layout
from IPython.display import display

def train_model(data, selected_columns, columns, epochs, batch_size):
    try:
        target_indices = [columns.index(col) for col in selected_columns]
        print(f"Выбраны столбцы: {selected_columns} (индексы: {target_indices})")

        # Извлечение данных
        target = data[:, target_indices]
        X = np.delete(data, target_indices, axis=1)

        # Улучшенная предобработка данных (стандартизация)
        X_mean = np.mean(X, axis=0)
        X_std = np.std(X, axis=0)
        epsilon = 1e-8
        X_norm = (X - X_mean) / (X_std + epsilon)

        # Сохранение параметров предобработки
        np.savez('preprocessing_params.npz', 
                X_mean=X_mean, 
                X_std=X_std,
                target_indices=target_indices,
                columns=columns)

        # Регуляризатор
        reg = L1L2(l1=1e-5, l2=1e-4)

        # Улучшенная архитектура модели
        model = Sequential()
        model.add(Input(shape=(X.shape[1],)))
        
        # Скрытые слои с батч-нормализацией и dropout
        model.add(Dense(128, activation='elu', kernel_regularizer=reg))
        model.add(BatchNormalization())
        model.add(Dropout(0.3))
        
        model.add(Dense(64, activation='elu', kernel_regularizer=reg))
        model.add(BatchNormalization())
        model.add(Dropout(0.2))
        
        model.add(Dense(32, activation='elu', kernel_regularizer=reg))
        model.add(BatchNormalization())
        
        # Выходной слой
        model.add(Dense(len(target_indices), activation='linear'))

        # Callback'и
        callbacks = [
            EarlyStopping(
                monitor='val_loss',
                patience=30,
                restore_best_weights=True,
                min_delta=1e-4,
                verbose=1
            ),
            ReduceLROnPlateau(
                monitor='val_loss',
                factor=0.8,
                patience=15,
                min_lr=1e-7
            )
        ]

        # Компиляция с настройкой оптимизатора
        model.compile(
            optimizer='adam',
            loss='mse',
            metrics=['mae', 'mse']
        )

        # Обучение с увеличенным числом эпох
        history = model.fit(
            X_norm,
            target,
            epochs=epochs,
            batch_size=batch_size,
            validation_split=0.2,
            callbacks=callbacks,
            verbose=1
        )

        model.save('my_model.h5')
        print("Модель успешно обучена!")

        # Сохранение истории обучения
        np.save('training_history.npy', history.history)

        with open('selected_columns.txt', 'w') as f:
            f.write(str(selected_columns))

    except Exception as e:
        print(f"Ошибка при обучении: {str(e)}")

def create_column_selector(data, columns):
    # Разбиваем столбцы на 3 группы
    column_groups = [columns[i::3] for i in range(3)]
    
    # Создаем чекбоксы для каждой группы
    checkbox_groups = []
    all_checkboxes = []  # Сохраняем все чекбоксы для доступа
    
    for group in column_groups:
        group_checkboxes = [widgets.Checkbox(value=False, description=col) for col in group]
        all_checkboxes.extend(group_checkboxes)
        vbox = widgets.VBox(group_checkboxes)
        checkbox_groups.append(vbox)

    # Собираем чекбоксы в горизонтальный контейнер
    checkboxes_container = widgets.HBox(checkbox_groups)

    # Ползунки для настройки параметров обучения
    epochs_widget = widgets.IntSlider(
        value=100,
        min=1,
        max=500,
        step=1,
        description='Количество эпох:',
        disabled=False
    )

    batch_size_widget = widgets.IntSlider(
        value=32,
        min=1,
        max=256,
        step=1,
        description='Размер батча:',
        disabled=False
    )

    # Кнопка для подтверждения выбора
    confirm_btn = widgets.Button(description="Подтвердить выбор")

    # Вывод результатов
    output = widgets.Output()

    def on_confirm_click(b):
        selected_columns = [cb.description for cb in all_checkboxes if cb.value]
        
        if not selected_columns:
            with output:
                print("Ошибка: Выберите хотя бы один столбец!")
            return

        with output:
            print(f"Выбраны столбцы: {selected_columns}")

            if os.path.exists('my_model.h5'):
                retrain_widget = widgets.RadioButtons(
                    options=['Да', 'Нет'],
                    description='Переобучить модель?',
                    disabled=False
                )

                def on_retrain_click(b):
                    if retrain_widget.value == 'Да':
                        train_model(data, selected_columns, columns, epochs_widget.value, batch_size_widget.value)
                    else:
                        print("Используется существующая модель.")

                retrain_btn = widgets.Button(description="Подтвердить")
                retrain_btn.on_click(on_retrain_click)

                display(retrain_widget)
                display(retrain_btn)
            else:
                train_model(data, selected_columns, columns, epochs_widget.value, batch_size_widget.value)

    confirm_btn.on_click(on_confirm_click)

    # Отображение интерфейса
    display(widgets.VBox([
        checkboxes_container,
        epochs_widget,
        batch_size_widget,
        confirm_btn,
        output
    ]))

if __name__ == "__main__":
    if not os.path.exists('input.txt'):
        print("Ошибка: Сначала создайте input.txt!")
    else:
        with open('input.txt', 'r') as f:
            columns = eval(f.readline())
            data = np.array(eval(f.readline()))

        create_column_selector(data, columns)