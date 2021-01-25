import {Proizvod} from "./proizvod.js"

export class Prodavnica
{
    constructor(ime, id)
    {
        this.id = id;
        this.ime = ime;
        this.proizvodi = [];
        this.container = null;
    }

    dodajProizvod(noviProizvod)
    {
        this.proizvodi.push(noviProizvod);
    }

    crtaj(host)
    {
        if(!host)
        {
            throw new Error("Nema hosta");
        }

        this.container = document.createElement("div");
        host.appendChild(this.container);
        this.container.classname = "divProzor";

        const divTabela = document.createElement("div");
        divTabela.className = "divTabela";
        this.container.appendChild(divTabela);
        
        const labNaslov = document.createElement("h3");
        labNaslov.innerHTML = this.ime;
        divTabela.appendChild(labNaslov);

        const tabela = document.createElement("table");
        divTabela.appendChild(tabela);
        this.crtajHeader(tabela);
        let tbody = document.createElement("tbody");
        tabela.appendChild(tbody);
        this.proizvodi.forEach((proiz, index) => {
            const r = proiz.crtajRed(tbody);
            this.dodajDeleteDugme(r, proiz, index);
        });
    }

    crtajHeader(tabela)
    {
        const header = document.createElement("thead");
        tabela.appendChild(header);
        const red = document.createElement("th");
         header.appendChild(red);

         let el = document.createElement("th");
         el.innerHTML = "Šifra";
         red.appendChild(el);

         el = document.createElement("th");
         el.innerHTML = "Ime";
         red.appendChild(el);

         el = document.createElement("th");
         el.innerHTML = "Cena";
         red.appendChild(el);

         el = document.createElement("th");
         el.innerHTML = "Količina";
         red.appendChild(el);

         el = document.createElement("th");
         red.appendChild(el);
    }

    dodajDeleteDugme(r, proiz, index)
    {
        const delDugme = document.createElement("button");
        delDugme.innerHTML = "Izbrisi";
        r.appendChild(delDugme);
        delDugme.onclick = (ev) =>
        {
            this.izbrisiProizvod(proiz, index, r);
        }
    }

    izbrisiProizvod(proiz, index, polje)
    {
        fetch("https://localhost:5000/PROJEKAT/BrisiProizvod/" + proiz.id, {
        method: "DELETE" 
    }).then(p => {
        if (p.ok) 
        {
            this.proizvodi.splice(index, 1);
            const red = polje.parentNode;
            polje.parentNode.parentNode.removeChild(red);
        }
    });
    }


}