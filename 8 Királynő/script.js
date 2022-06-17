var board = [];
var rows = 8;
var columns = 8;
var queensLeft = 8;
window.onload = function() {
    startGame();
}
function startGame() {
    document.getElementById("queens-count").innerText = queensLeft;
    for (let r = 0; r < rows; r++) {
        let row = [];
        for (let c = 0; c < columns; c++) {
            let tile = document.createElement("div");
            tile.id = r.toString() + "-" + c.toString();
            if((r % 2 == 0 && c % 2 == 0) || (r % 2 == 1 && c % 2 == 1)) {
                tile.classList.add("lightTile");
            }
            if((r % 2 == 0 && c % 2 == 1) || (r % 2 == 1 && c % 2 == 0)) {
                tile.classList.add("darkTile");
            }
            tile.addEventListener("click", clickTile);
            document.getElementById("gridc").append(tile);
            row.push(tile);
        }
        board.push(row);
    }
}
function clickTile() {
    let tile = this;
    if(tile.innerText == "" && queensLeft>0) {
        tile.innerText = "♛";
        queensLeft--;
        document.getElementById("queens-count").innerText = queensLeft;
    }
    else if(tile.innerText == "♛") {
        tile.innerText = "";
        queensLeft++;
        document.getElementById("queens-count").innerText = queensLeft;
    }
    if(queensLeft == 0) {
        alert("Több királynőt már nem tudsz letenni");
    }
}