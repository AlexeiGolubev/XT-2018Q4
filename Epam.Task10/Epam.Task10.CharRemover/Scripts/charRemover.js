'use strict';

var separators = ["?", "!", ":", ";", ",", ".", " ", "\t"],
    str, 
    arr, 
    letters = {}, 
    start = 0, 
    words = [], 
    result;

document.getElementById('removeButton').onclick = function () {
    str = document.getElementById('inputString').value;
    getWordsFromString(str);
    findSameLettersInWord();
    getResultStringWithRemovingSameLetters();
    alert(result);
    event.preventDefault();
}

function getWordsFromString(string) {
    arr = string.split('');
    arr.forEach(function (letter, i) {
        if (separators.indexOf(letter) != -1) {
            words.push(str.substr(start, i - start));
            start = i + 1;
        }
    });

    words.push(str.substr(start));
}

function findSameLettersInWord() {
    words.forEach(function (word) {
        word.split('').forEach(function (letter, i) {
            if (!letters[letter] && word.indexOf(letter, i + 1) != -1) {
                letters[letter] = true;
            }
        });
    });
}

function getResultStringWithRemovingSameLetters() {
    result = arr.filter(function (check) {
        return !letters[check];
    }).join('');
}