describe('Criar uma lista com nomes comuns no Brasil', function () {
    var arr = [];
    it('Seleciona os nomes no site', function () {
        cy.visit('http://www.babynames.ch/Info/Hitparade/poBr2011m')
        cy.wait(5000).then(
            () => {
                cy.get('.basicTable > tbody > tr > td > .mna').then(
                    elem => {
                        elem.each((num, res) => {
                            arr.push(res.textContent)
                        })
                    }
                )
            }
        )
        cy.visit('http://www.babynames.ch/Info/Hitparade/poBr2011f').then(
            () => {
                cy.get('.basicTable > tbody > tr > td > .fna').then(
                    elem => {
                        elem.each((num, res) => {
                            arr.push(res.textContent)
                        })
                    }
                )
            }
        ).then(
            () => {
                cy.writeFile('nomesBR.json', arr);
                console.log(arr);
            }
        )
    })
})