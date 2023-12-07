function idovaltozas(megadottido) {
    document.getElementById('ei').value = (`${megadottido} perc`);

}
function szures() {
    keresett = document.getElementById("keres");
    keresettnagy = keresett.value.toUpperCase();
    mind = document.getElementById("mind").checked;
    olcso = document.getElementById("olcso").checked;
    atl = document.getElementById("atl").checked;
    mf = document.getElementById("mf").checked;
    kolts = document.getElementById("kolts").checked;
    ido = document.getElementById("ido").value;
    tipus = document.getElementById("tipus").value;
    gm = document.getElementById("gm").checked;
    lm = document.getElementById("lm").checked;
    cm = document.getElementById("cm").checked;
    va = document.getElementById("va").checked;
    vn = document.getElementById("vn").checked;
    kal = document.getElementById("kcal").value;
    tablazat = document.getElementById("etelek");
    tr = tablazat.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        A = tr[i].getElementsByTagName("td")[0];
        B = tr[i].getElementsByTagName("td")[1];
        C = tr[i].getElementsByTagName("td")[2];
        E = tr[i].getElementsByTagName("td")[3];
        F = tr[i].getElementsByTagName("td")[4];
        G = tr[i].getElementsByTagName("td")[5];
        H = tr[i].getElementsByTagName("td")[6];
        I = tr[i].getElementsByTagName("td")[7];
        J = tr[i].getElementsByTagName("td")[9];
        K = tr[i].getElementsByTagName("td")[8];
        if (A) {
            nev = A.textContent || A.innerText;
            perc = B.textContent.slice(0, -5);
            arkateg = C.textContent;
            gluten = E.textContent;
            laktoz = F.textContent;
            cukor = G.textContent;
            vega = H.textContent;
            vegan = I.textContent;
            fogas = J.textContent;
            kaloria = K.textContent;
            if (
                /*névre szűrés*/
                (nev.toUpperCase().indexOf(keresettnagy) > -1) &&
                /*árkategóriára szűrés*/
                (
                    ((arkateg == "olcsó") && (olcso)) ||
                    ((arkateg == "átlagos") && (atl)) ||
                    ((arkateg == "megfizethető") && (mf)) ||
                    ((arkateg == "költséges") && (kolts)) ||
                    (mind)
                ) &&
                /*elkészítési időre szűrés*/
                (
                    (parseInt(perc) <= parseInt(ido))
                ) &&
                /*fogásra szűrés*/
                (
                    (fogas == (tipus)) || (tipus == "Mind")
                ) &&
                /*allergénekre szűrés*/
                (
                    (((gluten == "G") && (gm)) || (!gm))
                ) &&
                (
                    (((laktoz == "L") && (lm)) || (!lm))
                ) &&
                (
                    (((cukor == "C") && (cm)) || (!cm))
                ) &&
                (
                    (((vega == "V") && (va)) || (!va))
                ) &&
                (
                    (((vegan == "N") && (vn)) || (!vn))
                ) &&
                ((parseInt(kal) == 0) ||
                    (kal == "") ||
                    (parseInt(kaloria) <= parseInt(kal))
                )
            ) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function current() {
    alert("Épp ezen az oldalon böngészel, kérlek válassz másikat!")
}