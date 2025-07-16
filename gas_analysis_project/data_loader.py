import pandas as pd
import numpy as np
import os

# Исключаемые столбцы
excluded_columns = ["Дата", "Время", "Примечание"]

def load_files():
    from google.colab import files
    uploaded = files.upload()
    file_paths = list(uploaded.keys())

    dfs = []
    for file_path in file_paths:
        if file_path.endswith('.xlsx'):
            df = pd.read_excel(file_path)
            dfs.append(df)

    # Проверка совпадения столбцов
    base_columns = set(dfs[0].columns)
    for df in dfs[1:]:
        if set(df.columns) != base_columns:
            print("Ошибка: Столбцы в файлах не совпадают!")
            return None

    dataframe = pd.concat(dfs, ignore_index=True)
    return dataframe

def create_input_file(dataframe):
    try:
        # Сначала заменяем NaN на 0
        data_to_save = dataframe.drop(columns=excluded_columns, errors='ignore').fillna(0)
        data_list = data_to_save.values.tolist()

        # Сохраняем данные и названия столбцов в файл
        with open('input.txt', 'w') as f:
            # Сохраняем названия столбцов
            f.write(str(list(data_to_save.columns)) + "\n")
            # Сохраняем данные
            f.write(str(data_list))
        print("Файл input.txt успешно создан!")
    except Exception as e:
        print(f"Ошибка: {str(e)}")

# Загрузка данных и создание input2.txt
if __name__ == "__main__":
    dataframe = load_files()
    if dataframe is not None:
        create_input_file(dataframe)