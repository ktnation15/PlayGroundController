const url = 'https://playgroundcontroller20240610114405.azurewebsites.net/api/PlayGrounds';

Vue.createApp({
    data() {
        return {
            PlayGrounds: [],
            PlayGround: {
                id: 0,
                Name: "",
                MaxChildren: 0,
                MinChildAge: 0,
            },
            GetPlayGround: {
                id: 0,
                Name: "",
                MaxChildren: 0,
                MinChildAge: 0,
            },
            deleteId: 0,
            PgIdToGet: null,
        }

    },
    async created() {
        await this.GetPG();
    },
    methods: {
        GetPG() {
            axios.get(url)
                .then(response => {
                    this.PlayGrounds = response.data;
                })
                .catch(error => {
                    console.log(error);
                });
        },
        async getById() {
            try {
                const response = await axios.get(url + "/" + id);
                this.GetPlayGround = response.data;
            } catch (error) {
                console.log(error);

            }
        },
        addPG() {
            this.PlayGrounds.push({
                Id: this.PlayGround.Id,
                Name: this.PlayGround.Name,
                MaxChildren: this.PlayGround.MaxChildren,
                MinChildAge: this.PlayGround.MinChildAge,
            });
            this.PlayGround.Id = 0;
            this.PlayGround.Name = "";
            this.PlayGround.MaxChildren = 0;
            this.PlayGround.MinChildAge = 0;
        }
    }
}).mount('#app')