var NICKMELDRUM = {};

NICKMELDRUM.wordInWordList = function (word) {
    // todo: refactor with better array checking pattern
    for (var i = 0; i < NICKMELDRUM.wordList.length; i++) {
        if (word === NICKMELDRUM.wordList[i]) {
            return true;
        }
    }

    return false;
};

NICKMELDRUM.animateCell = function(cell, callback) {
    cell.animate({ backgroundColor: "#FF0000" }, 10)
        .animate({ backgroundColor: "#FFFFFF" }, 10, callback);
};

NICKMELDRUM.searchCallback = function (table, cellIndex) {
    if (cellIndex === undefined) {
        cellIndex = 0;
    }
    
    var boxWidth = table.find("tr:eq(0) td").length;
    var cellCount = table.find("td").length;
    var currentLineIndex = Math.floor(cellIndex / boxWidth);
    var currentRowIndex = cellIndex % boxWidth;
    var currentCell = table.find("tr:eq(" + currentLineIndex + ") td:eq(" + currentRowIndex + ")");

    var runSearchOnNextCell = function () {
        if (cellIndex < (cellCount - 1)) {
            NICKMELDRUM.searchCallback(table, ++cellIndex);
        }
    };

    NICKMELDRUM.animateCell(currentCell, runSearchOnNextCell);
};

NICKMELDRUM.processCell = function (table, direction, size) {
    if (direction === undefined) {
        direction = "left";
    }
    if (size === undefined) {
        size = 1;
    }

    var boxWidth = table.find("tr:eq(0) td").length;

    var currentCell = table.find("tr:eq(" + 0 + ") td:eq(" + 0 + ")");
    var wordCells = [currentCell];
    wordCells.push(table.find("tr:eq(" + 0 + ") td:eq(" + 1 + ")"));
    wordCells.push(table.find("tr:eq(" + 0 + ") td:eq(" + 2 + ")"));

    var wordFromCellArray = function (cellArray) {
        var word = "";

        $.each(cellArray, function (index, value) {
            word += value.text().trim();
        });

        return word;
    };

    var showWord = function (wordToShow, cellArray) {
        $.each(cellArray, function (index, value) {
            value.css("border", "green solid 1px");
        });
        $(".foundWords H3").after("<p>" + wordToShow + "</p>");
    };

    NICKMELDRUM.animateCell(currentCell);

    var word = wordFromCellArray(wordCells);
    var isAWord = NICKMELDRUM.wordInWordList(word);

    if (isAWord === false) {
        showWord(word, wordCells);
    }
};

NICKMELDRUM.startSearch = function () {
    $(".foundWords p").remove();
    var wordSearchTable = $(".wordsearch");
    NICKMELDRUM.processCell(wordSearchTable);
    
    return;
};

NICKMELDRUM.getWordListFromServer = function () {
    $.post("/Home/WordList", null, NICKMELDRUM.setWordList);
    $("#wordListButton").after("<img id='wordListLoadingImg' src='/ajax-loader.gif' alt='Loading...' />");
};

NICKMELDRUM.setWordList = function (responseText, textStatus) {
    if (textStatus === "success") {
        NICKMELDRUM.wordList = responseText;
    }

    $("#wordListLoadingImg").remove();
    $("#startSearchingButton").removeAttr("disabled");
};

NICKMELDRUM.bindButtonEvents = function () {
    $("#wordListButton").click(NICKMELDRUM.getWordListFromServer);
    $("#startSearchingButton").click(NICKMELDRUM.startSearch);
};

$(function () {
    NICKMELDRUM.bindButtonEvents();
});
