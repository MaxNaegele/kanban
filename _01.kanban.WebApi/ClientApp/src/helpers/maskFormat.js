export default function maskFormat(data, text) {
    if (data === '')
        return;

    let onlyNumbers = data.replace(/[^0-9]/g, '');
    if (onlyNumbers === '')
        return;

    let result = '';
    let format = text.split('');
    let numbers = onlyNumbers.split('');
    let item = '';
    let index = 0;
    for (var i in numbers) {
        let num = numbers[i];
        if (!!format[index]) {
            let caracter = format[index];
            while (caracter !== '0') {
                item = item + caracter;
                index++;
                caracter = format[index];
            }
            item = item + num;
            index++;
        } else {
            return;
        }
        result = item.replace('*', ' ');
    }
    return result;
}