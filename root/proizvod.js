export class Proizvod
{
    constructor(id, sifra, ime, cena, kolicina)
    {
        this.id = id;
        this.sifra = sifra;
        this.ime = ime;
        this.cena = cena;
        this.kolicina = kolicina;
    }

    crtajRed(tab)
    {
        const red = document.createElement("tr");
        tab.appendChild(red);
        let el = document.createElement("td");
        el.innerHTML = this.sifra;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.ime;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.cena;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.kolicina;
        el.className = "kolicina";
        red.appendChild(el);

        el = document.createElement("button");
        el.innerHTML = "Kupi";
        red.appendChild(el);
        el.onclick = (ev) => 
        {
           this.kupiProizvod(red);
        }
    }

    kupiProizvod(red)
    {
        var kolicinaTemp = this.kolicina;

        if (kolicinaTemp > 0)
        {
            kolicinaTemp--;
        }

        fetch("https://localhost:5000/PROJEKAT/Izmeni/" + this.id + "/" + kolicinaTemp, {
            method: "PUT"
        }).then(p => {
            if (p.ok)
            {
            this.kolicina = kolicinaTemp;

            const domKolicina = red.querySelector(".kolicina");
            domKolicina.innerHTML = this.kolicina;
            }
        });
    }
}