# RaslboyyGeneticAlgo

### Стадии
- Отбор
    - Оценка особей
    - Исключение слабых особей
    - Выживание рандомной группы слабых особей
- Скрещивание
- Мутация

--------
![ezgif-2-66a6c1ed87](https://user-images.githubusercontent.com/33222839/169855987-87ace248-5cee-413d-af0c-09acd9d89796.gif)

--------

![ezgif-2-43a74b66d2](https://user-images.githubusercontent.com/33222839/169856157-a6310aed-fc11-49cb-ab14-6a78c6e7baea.gif)

--------

![ezgif-2-e170e853f6](https://user-images.githubusercontent.com/33222839/169855735-d9d0c518-7c14-4a94-be3f-0b70595f6328.gif)

# Анализ
## Бенчмарки
|  Method | PopulationSize | MaxLenOfChromosome |        Mean |      Error |     StdDev | Allocated |
|-------- |--------------- |------------------- |------------:|-----------:|-----------:|----------:|
| Solving |            100 |                100 |    75.72 us |   1.657 us |   1.908 us |     51 KB |
| Solving |            100 |                500 |   210.10 us |  17.734 us |  20.422 us |     88 KB |
| Solving |            100 |               1000 |    95.38 us |   3.161 us |   3.246 us |     57 KB |
| Solving |            100 |               3000 | 1,708.90 us | 196.200 us | 218.075 us |    596 KB |
| Solving |            500 |                100 |   410.73 us |   6.011 us |   6.432 us |    245 KB |
| Solving |            500 |                500 |   403.73 us |  11.298 us |  13.011 us |    245 KB |
| Solving |            500 |               1000 |   402.38 us |   4.655 us |   4.981 us |    244 KB |
| Solving |            500 |               3000 |   593.32 us |  25.524 us |  27.310 us |    297 KB |
| Solving |           1000 |                100 | 1,038.06 us | 171.611 us | 197.627 us |    487 KB |
| Solving |           1000 |                500 | 1,129.37 us |  18.859 us |  20.179 us |    541 KB |
| Solving |           1000 |               1000 | 1,020.76 us |  18.904 us |  19.413 us |    488 KB |
| Solving |           1000 |               3000 | 3,548.00 us | 239.612 us | 256.382 us |  1,133 KB |
## dotTrace
`PopulationSize = 200 MaxLenOfChromosome = 2000`
